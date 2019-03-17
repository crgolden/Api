namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Abstractions.Controllers;
    using CartProducts;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CartProductsController : RangedClassController<CartProduct, CartProductModel, Guid>
    {
        public CartProductsController(IMediator mediator) : base(mediator)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<CartProduct>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> List([DataSourceRequest] DataSourceRequest request)
        {
            return await List(
                request: User.IsInRole("Admin")
                    ? new CartProductListRequest(ModelState, request)
                    {
                        UserId = Guid.Parse(User.FindFirst("sub").Value)
                    }
                    : new CartProductListRequest(ModelState, request),
                notification: new CartProductListNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(CartProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Read([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 2) return BadRequest(keyValues);
            return await Read(
                request: new CartProductReadRequest(keyValues[0], keyValues[1]),
                notification: new CartProductReadNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(CartProduct[]), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> ReadRange([FromQuery] Guid[][] keyValues)
        {
            return await ReadRange(
                request: new CartProductReadRangeRequest(keyValues),
                notification: new CartProductReadRangeNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Update([FromBody] CartProductModel cartProduct)
        {
            return await Update(
                request: new CartProductUpdateRequest(cartProduct),
                notification: new CartProductUpdateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> UpdateRange([FromBody] CartProductModel[] cartProducts)
        {
            return await UpdateRange(
                request: new CartProductUpdateRangeRequest(cartProducts),
                notification: new CartProductUpdateRangeNotification()).ConfigureAwait(false);
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
        [ProducesResponseType(typeof(CartProduct[]), (int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> CreateRange([FromBody] CartProductModel[] cartProducts)
        {
            return await CreateRange(
                request: new CartProductCreateRangeRequest(cartProducts),
                notification: new CartProductCreateRangeNotification()).ConfigureAwait(false);
        }

        [HttpDelete]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 2) return BadRequest(keyValues);
            return await Delete(
                request: new CartProductDeleteRequest(keyValues[0], keyValues[1]),
                notification: new CartProductDeleteNotification()).ConfigureAwait(false);
        }

        [HttpDelete]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> DeleteRange([FromQuery] Guid[][] keyValues)
        {
            return await DeleteRange(
                request: new CartProductDeleteRangeRequest(keyValues),
                notification: new CartProductDeleteRangeNotification()).ConfigureAwait(false);
        }
    }
}
