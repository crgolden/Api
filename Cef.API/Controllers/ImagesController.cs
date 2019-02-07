namespace Cef.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Core.Controllers;
    using Core.Interfaces;
    using Core.Utilities;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Options;
    using Relationships;

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
                    .Where(x => AzureFilesUtility.IsImage(x) && x.Length > 0)
                    .ToDictionary(x =>
                {
                    var index = x.FileName.LastIndexOf('.');
                    var extension = x.FileName.Substring(index);
                    return $"{Guid.NewGuid()}{extension}";
                }, x => x);

                foreach (var (fileName, file) in images)
                {
                    var uri = await AzureFilesUtility.UploadFileToStorageAsync(
                        file: file,
                        fileName: fileName,
                        accountName: _azureBlobStorage.AccountName,
                        accountKey: _azureBlobStorage.AccountKey,
                        containerName: _azureBlobStorage.ImageContainer);
                    filesResult.Add(new File
                    {
                        ContentType = file.ContentType,
                        FileName = fileName,
                        Name = file.FileName,
                        Uri = $"{uri}",
                        ProductFiles = new List<ProductFile>()
                    });
                    filesResult.Add(new File
                    {
                        ContentType = file.ContentType,
                        FileName = fileName,
                        Name = file.FileName,
                        Uri = $"{uri}".Replace(
                            oldValue: $"{_azureBlobStorage.ImageContainer}/",
                            newValue: $"{_azureBlobStorage.ThumbnailContainer}/"),
                        ProductFiles = new List<ProductFile>()
                    });
                }

                await Service.CreateRange(filesResult);
                return Content(JsonConvert.SerializeObject(filesResult, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }));
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return BadRequest();
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<File>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            return await base.Index(request);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(File), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromRoute] Guid id)
        {
            return await base.Details(id);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] File model)
        {
            return await base.Edit(id, model);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] List<File> models)
        {
            return await base.EditRange(models);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(File), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] File model)
        {
            return await base.Create(model);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(List<File>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] List<File> models)
        {
            return await base.EditRange(models);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await base.Delete(id);
        }
    }
}
