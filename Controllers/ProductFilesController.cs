namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Abstractions.Controllers;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;
    using ProductFiles;
    using Shared;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductFilesController : RangedClassController<ProductFile, ProductFileModel, Guid>
    {
        public ProductFilesController(IMediator mediator, IMemoryCache cache, IOptions<CacheOptions> cacheOptions)
            : base(mediator, cache, cacheOptions)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<ProductFile>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> List([DataSourceRequest] DataSourceRequest request)
        {
            return await List(
                request: new ProductFileListRequest(ModelState, request),
                notification: new ProductFileListNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ProductFile), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Read([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 2) return BadRequest(keyValues);
            return await Read(
                request: new ProductFileReadRequest(keyValues[0], keyValues[1]),
                notification: new ProductFileReadNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ProductFile[]), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> ReadRange([FromQuery] Guid[][] keyValues)
        {
            return await ReadRange(
                request: new ProductFileReadRangeRequest(keyValues),
                notification: new ProductFileReadRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Update([FromBody] ProductFileModel productFile)
        {
            return await Update(
                request: new ProductFileUpdateRequest(productFile),
                notification: new ProductFileUpdateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> UpdateRange([FromBody] ProductFileModel[] productFiles)
        {
            return await UpdateRange(
                request: new ProductFileUpdateRangeRequest(productFiles),
                notification: new ProductFileUpdateRangeNotification()).ConfigureAwait(false);
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
        [ProducesResponseType(typeof(ProductFile[]), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] ProductFileModel[] productFiles)
        {
            return await CreateRange(
                request: new ProductFileCreateRangeRequest(productFiles),
                notification: new ProductFileCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 2) return BadRequest(keyValues);
            return await Delete(
                request: new ProductFileDeleteRequest(keyValues[0], keyValues[1]),
                notification: new ProductFileDeleteNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> DeleteRange([FromQuery] Guid[][] keyValues)
        {
            return await DeleteRange(
                request: new ProductFileDeleteRangeRequest(keyValues),
                notification: new ProductFileDeleteRangeNotification()).ConfigureAwait(false);
        }
    }
}
