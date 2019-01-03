namespace Cef.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Core.Controllers;
    using Core.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;
    using Newtonsoft.Json;
    using Options;
    using Relationships;
    using Utilities;

    [Produces("application/json")]
    [Route("v1/[controller]/[action]")]
    [ApiController]
    public class ImagesController : BaseModelController<File>
    {
        private readonly AzureBlobStorage _azureBlobStorage;

        public ImagesController(
            IModelService<File> service,
            IOptions<StorageOptions> options,
            ILogger<ImagesController> logger) : base(service, logger)
        {
            _azureBlobStorage = options.Value.AzureBlobStorage;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {
            try
            {
                if (files.Count == 0)
                {
                    return BadRequest("No files received from the upload");
                }

                var filesResult = new List<File>();
                var images = files
                    .Where(x => FilesUtility.IsImage(x) && x.Length > 0)
                    .ToDictionary(x =>
                {
                    var index = x.FileName.LastIndexOf('.');
                    var extension = x.FileName.Substring(index);
                    return $"{Guid.NewGuid()}{extension}";
                }, x => x);

                foreach (var (fileName, file) in images)
                {
                    filesResult.Add(await GetFile(file, fileName, _azureBlobStorage.ImageContainer));
                }

                foreach (var (fileName, file) in images)
                {
                    filesResult.Add(await GetFile(file, fileName, _azureBlobStorage.ThumbnailContainer));
                }

                await Service.CreateRange(filesResult);
                return Content(JsonConvert.SerializeObject(filesResult));
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        public IActionResult GetThumbNails([FromBody] ICollection<string> fileNames)
        {
            try
            {
                var thumbnailUrls = FilesUtility.GetThumbNailUrls(fileNames, _azureBlobStorage);
                return Ok(thumbnailUrls);
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return BadRequest();
            }
        }

        private async Task<File> GetFile(IFormFile formFile, string fileName, string containerName)
        {
            var uri = await FilesUtility.UploadFileToStorage(
                file: formFile,
                fileName: fileName,
                accountName: _azureBlobStorage.AccountName,
                accountKey: _azureBlobStorage.AccountKey,
                containerName: containerName);
            return new File
            {
                ContentDisposition = formFile.ContentDisposition,
                ContentType = formFile.ContentType,
                FileName = fileName,
                Name = formFile.FileName,
                Length = formFile.Length,
                Uri = $"{uri}",
                ProductFiles = new List<ProductFile>()
            };
        }
    }
}
