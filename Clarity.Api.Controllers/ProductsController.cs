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
    using Microsoft.Extensions.Logging;
    using Products;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductsController : Controller<Product, Guid>
    {
        public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            var indexRequest = new ProductIndexRequest(ModelState, request)
            {
                Active = !User.IsInRole("Admin")
            };
            return await base.Index(indexRequest).ConfigureAwait(false);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            var detailsRequest = new ProductDetailsRequest(ids[0])
            {
                Active = !User.IsInRole("Admin")
            };
            return await base.Details(detailsRequest).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] Product product)
        {
            var editRequest = new ProductEditRequest(product);
            return await base.Edit(editRequest).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<Product> products)
        {
            var editRangeRequest = new ProductEditRangeRequest(products);
            return await base.EditRange(editRangeRequest).ConfigureAwait(false);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] Product product)
        {
            var createRequest = new ProductCreateRequest(product);
            return await base.Create(createRequest).ConfigureAwait(false);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Product>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<Product> products)
        {
            var createRangeRequest = new ProductCreateRangeRequest(products);
            return await base.CreateRange(createRangeRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            var deleteRequest = new ProductDeleteRequest(ids[0]);
            return await base.Delete(deleteRequest).ConfigureAwait(false);
        }
    }
}
