namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Files;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ImagesController : Controller<File, FileModel, Guid>
    {
        public ImagesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {
            if (files.Count == 0) return BadRequest("No files received from the upload");
            using (var tokenSource = new CancellationTokenSource())
            {
                var request = new FileUploadRequest(files);
                var notification = new FileUploadNotification();
                try
                {
                    notification.Files = request.Files;
                    notification.EventId = EventIds.UploadStart;
                    await Mediator.Publish(notification, tokenSource.Token).ConfigureAwait(false);

                    notification.Models = await Mediator.Send(request, tokenSource.Token).ConfigureAwait(false);
                    notification.EventId = EventIds.UploadEnd;
                    await Mediator.Publish(notification, tokenSource.Token).ConfigureAwait(false);
                    return Content(JsonConvert.SerializeObject(notification.Models));
                }
                catch (Exception e)
                {
                    notification.EventId = EventIds.UploadError;
                    notification.Exception = e;
                    await Mediator.Publish(notification, tokenSource.Token).ConfigureAwait(false);
                    return BadRequest(request.Files);
                }
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<File>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request)
        {
            return await base.Index(
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
            return await base.Details(
                request: new FileDetailsRequest(ids[0]),
                notification: new FileDetailsNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] FileModel file)
        {
            return await base.Edit(
                request: new FileEditRequest(file),
                notification: new FileEditNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<FileModel> files)
        {
            return await base.EditRange(
                request: new FileEditRangeRequest(files),
                notification: new FileEditRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(File), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] FileModel file)
        {
            return await base.Create(
                request: new FileCreateRequest(file),
                notification: new FileCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<File>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<FileModel> files)
        {
            return await base.CreateRange(
                request: new FileCreateRangeRequest(files),
                notification: new FileCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await base.Delete(
                request: new FileDeleteRequest(ids[0]),
                notification: new FileDeleteNotification()).ConfigureAwait(false);
        }
    }
}
