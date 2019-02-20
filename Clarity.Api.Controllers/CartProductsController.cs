namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using CartProducts;
    using Core;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CartProductsController : Controller<CartProduct, Guid>
    {
        public CartProductsController(IMediator mediator, ILogger<CartProductsController> logger)
            : base(mediator, logger)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<CartProduct>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            var indexRequest = new CartProductIndexRequest(ModelState, request);
            return await base.Index(indexRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(CartProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 2) return BadRequest(ids);
            var detailsRequest = new CartProductDetailsRequest(ids[0], ids[1]);
            return await base.Details(detailsRequest).ConfigureAwait(false);
        }

        [HttpPut]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] CartProduct cartProduct)
        {
            var editRequest = new CartProductEditRequest(cartProduct);
            return await base.Edit(editRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<CartProduct> cartProducts)
        {
            var editRangeRequest = new CartProductEditRangeRequest(cartProducts);
            return await base.EditRange(editRangeRequest).ConfigureAwait(false);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CartProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] CartProduct cartProduct)
        {
            var createRequest = new CartProductCreateRequest(cartProduct);
            return await base.Create(createRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<CartProduct>), (int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<CartProduct> cartProducts)
        {
            var createRangeRequest = new CartProductCreateRangeRequest(cartProducts);
            return await base.CreateRange(createRangeRequest).ConfigureAwait(false);
        }

        [HttpDelete]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 2) return BadRequest(ids);
            var deleteRequest = new CartProductDeleteRequest(ids[0], ids[1]);
            return await base.Delete(deleteRequest).ConfigureAwait(false);
        }
    }
}
