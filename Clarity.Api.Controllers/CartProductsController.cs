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

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CartProductsController : Controller<CartProduct, CartProductModel, Guid>
    {
        public CartProductsController(IMediator mediator) : base(mediator)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<CartProduct>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request)
        {
            return await Index(
                request: User.IsInRole("Admin")
                    ? new CartProductIndexRequest(ModelState, request)
                    {
                        UserId = Guid.Parse(User.FindFirst("sub").Value)
                    }
                    : new CartProductIndexRequest(ModelState, request),
                notification: new CartProductIndexNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(CartProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 2) return BadRequest(ids);
            return await Details(
                request: new CartProductDetailsRequest(ids[0], ids[1]),
                notification: new CartProductDetailsNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] CartProductModel cartProduct)
        {
            return await Edit(
                request: new CartProductEditRequest(cartProduct),
                notification: new CartProductEditNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<CartProductModel> cartProducts)
        {
            return await EditRange(
                request: new CartProductEditRangeRequest(cartProducts),
                notification: new CartProductEditRangeNotification()).ConfigureAwait(false);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CartProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] CartProductModel cartProduct)
        {
            return await Create(
                request: new CartProductCreateRequest(cartProduct),
                notification: new CartProductCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<CartProduct>), (int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<CartProductModel> cartProducts)
        {
            return await CreateRange(
                request: new CartProductCreateRangeRequest(cartProducts),
                notification: new CartProductCreateRangeNotification()).ConfigureAwait(false);
        }

        [HttpDelete]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 2) return BadRequest(ids);
            return await Delete(
                request: new CartProductDeleteRequest(ids[0], ids[1]),
                notification: new CartProductDeleteNotification()).ConfigureAwait(false);
        }
    }
}
