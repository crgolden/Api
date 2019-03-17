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
    using ProductCategories;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductCategoriesController : RangedClassController<ProductCategory, ProductCategoryModel, Guid>
    {
        public ProductCategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<ProductCategory>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> List([DataSourceRequest] DataSourceRequest request)
        {
            return await List(
                request: new ProductCategoryListRequest(ModelState, request),
                notification: new ProductCategoryListNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ProductCategory), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Read([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 2) return BadRequest(keyValues);
            return await Read(
                request: new ProductCategoryReadRequest(keyValues[0], keyValues[1]),
                notification: new ProductCategoryReadNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ProductCategory[]), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> ReadRange([FromQuery] Guid[][] keyValues)
        {
            return await ReadRange(
                request: new ProductCategoryReadRangeRequest(keyValues),
                notification: new ProductCategoryReadRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Update([FromBody] ProductCategoryModel productCategory)
        {
            return await Update(
                request: new ProductCategoryUpdateRequest(productCategory),
                notification: new ProductCategoryUpdateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> UpdateRange([FromBody] ProductCategoryModel[] productCategories)
        {
            return await UpdateRange(
                request: new ProductCategoryUpdateRangeRequest(productCategories),
                notification: new ProductCategoryUpdateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ProductCategory), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] ProductCategoryModel productCategory)
        {
            return await Create(
                request: new ProductCategoryCreateRequest(productCategory),
                notification: new ProductCategoryCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ProductCategory[]), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] ProductCategoryModel[] productCategories)
        {
            return await CreateRange(
                request: new ProductCategoryCreateRangeRequest(productCategories),
                notification: new ProductCategoryCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 2) return BadRequest(keyValues);
            return await Delete(
                request: new ProductCategoryDeleteRequest(keyValues[0], keyValues[1]),
                notification: new ProductCategoryDeleteNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> DeleteRange([FromQuery] Guid[][] keyValues)
        {
            return await DeleteRange(
                request: new ProductCategoryDeleteRangeRequest(keyValues),
                notification: new ProductCategoryDeleteRangeNotification()).ConfigureAwait(false);
        }
    }
}
