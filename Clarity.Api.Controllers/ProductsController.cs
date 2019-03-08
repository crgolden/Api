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
    using Products;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductsController : Controller<Product, ProductModel, Guid>
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request)
        {
            return await Index(
                request: new ProductIndexRequest(ModelState, request)
                {
                    Active = !User.IsInRole("Admin")
                },
                notification: new ProductIndexNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await Details(
                request: new ProductDetailsRequest(ids[0])
                {
                    Active = !User.IsInRole("Admin")
                },
                notification: new ProductDetailsNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] ProductModel product)
        {
            return await Edit(
                request: new ProductEditRequest(product),
                notification: new ProductEditNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<ProductModel> products)
        {
            return await EditRange(
                request: new ProductEditRangeRequest(products),
                notification: new ProductEditRangeNotification()).ConfigureAwait(false);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] ProductModel product)
        {
            return await Create(
                request: new ProductCreateRequest(product),
                notification: new ProductCreateNotification()).ConfigureAwait(false);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Product>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<ProductModel> products)
        {
            return await CreateRange(
                request: new ProductCreateRangeRequest(products),
                notification: new ProductCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await Delete(
                request: new ProductDeleteRequest(ids[0]),
                notification: new ProductDeleteNotification()).ConfigureAwait(false);
        }
    }
}
