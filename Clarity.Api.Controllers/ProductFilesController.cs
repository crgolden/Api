namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Core;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProductFiles;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductFilesController : Controller<ProductFile, ProductFileModel, Guid>
    {
        public ProductFilesController(IMediator mediator) : base(mediator)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<ProductFile>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request)
        {
            return await Index(
                request: new ProductFileIndexRequest(ModelState, request),
                notification: new ProductFileIndexNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ProductFile), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 2) return BadRequest(ids);
            return await Details(
                request: new ProductFileDetailsRequest(ids[0], ids[1]),
                notification: new ProductFileDetailsNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] ProductFileModel productFile)
        {
            return await Edit(
                request: new ProductFileEditRequest(productFile),
                notification: new ProductFileEditNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<ProductFileModel> productFiles)
        {
            return await EditRange(
                request: new ProductFileEditRangeRequest(productFiles),
                notification: new ProductFileEditRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ProductFile), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] ProductFileModel productFile)
        {
            return await Create(
                request: new ProductFileCreateRequest(productFile),
                notification: new ProductFileCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<ProductFile>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<ProductFileModel> productFiles)
        {
            return await CreateRange(
                request: new ProductFileCreateRangeRequest(productFiles),
                notification: new ProductFileCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 2) return BadRequest(ids);
            return await Delete(
                request: new ProductFileDeleteRequest(ids[0], ids[1]),
                notification: new ProductFileDeleteNotification()).ConfigureAwait(false);
        }
    }
}
