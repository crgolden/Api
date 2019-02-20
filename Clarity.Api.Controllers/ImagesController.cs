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
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ImagesController : Controller<File, Guid>
    {
        public ImagesController(IMediator mediator, ILogger<ImagesController> logger)
            : base(mediator, logger)
        {
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {
            try
            {
                if (files.Count == 0)
                {
                    return BadRequest("No files received from the upload");
                }

                Logger.LogInformation(
                    eventId: new EventId((int)EventIds.UploadStart, $"{EventIds.UploadStart}"),
                    message: "Uploading files {Files} at {Time}",
                    args: new object[] { files, DateTime.UtcNow });
                var createRangeRequest = new FileCreateRangeRequest(new File[0])
                {
                    Files = files
                };
                var response = await Mediator.Send(createRangeRequest).ConfigureAwait(false);
                var result = JsonConvert.SerializeObject(
                    value: response,
                    settings: new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()

                    });
                Logger.LogInformation(
                    eventId: new EventId((int)EventIds.UploadEnd, $"{EventIds.UploadEnd}"),
                    message: "Uploaded files {Files} at {Time}",
                    args: new object[] { files, DateTime.UtcNow });
                return Content(result);
            }
            catch (Exception e)
            {
                Logger.LogError(
                    eventId: new EventId((int)EventIds.UploadError, $"{EventIds.UploadError}"),
                    exception: e,
                    message: "Error uploading files {Files} at {Time}",
                    args: new object[] { files, DateTime.UtcNow });
                return BadRequest(files);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<File>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            var indexRequest = new FileIndexRequest(ModelState, request);
            return await base.Index(indexRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(File), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            var detailsRequest = new FileDetailsRequest(ids[0]);
            return await base.Details(detailsRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] File file)
        {
            var editRequest = new FileEditRequest(file);
            return await base.Edit(editRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<File> files)
        {
            var editRangeRequest = new FileEditRangeRequest(files);
            return await base.EditRange(editRangeRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(File), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] File file)
        {
            var createRequest = new FileCreateRequest(file);
            return await base.Create(createRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<File>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<File> files)
        {
            var createRangeRequest = new FileCreateRangeRequest(files);
            return await base.CreateRange(createRangeRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            var deleteRequest = new FileDeleteRequest(ids[0]);
            return await base.Delete(deleteRequest).ConfigureAwait(false);
        }
    }
}
