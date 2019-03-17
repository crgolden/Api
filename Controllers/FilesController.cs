namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Core;
    using Files;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class FilesController : FilesController<File, FileModel, Guid>
    {
        private readonly string _imagesContainer;
        private readonly string _thumbnailsContainer;

        public FilesController(IMediator mediator, IOptions<StorageOptions> storageOptions) : base(mediator)
        {
            _imagesContainer = storageOptions.Value.ImageContainer;
            _thumbnailsContainer = storageOptions.Value.ThumbnailContainer;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<FileModel>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Upload(IFormFileCollection files)
        {
            return await Upload(
                request: new FileUploadRequest(files, _imagesContainer),
                notification: new FileUploadNotification());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<string, Guid?>>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Remove([FromForm] string[] fileNames, [FromForm] Guid[][] keys = null)
        {
            return await Remove(
                request: new FileRemoveRequest(fileNames, _imagesContainer, _thumbnailsContainer, keys),
                notification: new FileRemoveNotification());
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<File>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> List([DataSourceRequest] DataSourceRequest request)
        {
            return await List(
                request: new FileListRequest(ModelState, request),
                notification: new FileListNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(File), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Read([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Read(
                request: new FileReadRequest(keyValues[0]),
                notification: new FileReadNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Update([FromBody] FileModel file)
        {
            return await Update(
                request: new FileUpdateRequest(file),
                notification: new FileUpdateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(File), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] FileModel file)
        {
            return await Create(
                request: new FileCreateRequest(file),
                notification: new FileCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Delete(
                request: new FileDeleteRequest(keyValues[0]),
                notification: new FileDeleteNotification()).ConfigureAwait(false);
        }
    }
}
