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

    [Route("v1/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class FilesController : FilesController<File, FileModel, Guid>
    {
        public FilesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<FileModel>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Upload(IFormFileCollection files)
        {
            return await Upload(
                request: new FileUploadRequest(files),
                notification: new FileUploadNotification());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<string, Guid?>>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Remove([FromForm] string[] fileNames, [FromForm] Guid[][] keys = null)
        {
            return await Remove(
                request: new FileRemoveRequest(fileNames, keys),
                notification: new FileRemoveNotification());
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<File>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request)
        {
            return await Index(
                request: new FileIndexRequest(ModelState, request),
                notification: new FileIndexNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(File), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await Details(
                request: new FileDetailsRequest(ids[0]),
                notification: new FileDetailsNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] FileModel payment)
        {
            return await Edit(
                request: new FileEditRequest(payment),
                notification: new FileEditNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<FileModel> payments)
        {
            return await EditRange(
                request: new FileEditRangeRequest(payments),
                notification: new FileEditRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(File), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] FileModel payment)
        {
            return await Create(
                request: new FileCreateRequest(payment),
                notification: new FileCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<File>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<FileModel> payments)
        {
            return await CreateRange(
                request: new FileCreateRangeRequest(payments),
                notification: new FileCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await Delete(
                request: new FileDeleteRequest(ids[0]),
                notification: new FileDeleteNotification()).ConfigureAwait(false);
        }
    }
}
