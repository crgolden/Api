namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Carts;
    using Abstractions.Controllers;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CartsController : ClassController<Cart, CartModel, Guid>
    {
        public CartsController(IMediator mediator) : base(mediator)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<Cart>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> List([DataSourceRequest] DataSourceRequest request)
        {
            return await List(
                request: new CartListRequest(ModelState, request),
                notification: new CartListNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Read([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Read(
                request: Guid.TryParse(User.FindFirst("sub")?.Value, out var userId)
                    ? new CartReadRequest(keyValues[0], userId)
                    : new CartReadRequest(keyValues[0]),
                notification: new CartReadNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Update([FromBody] CartModel cart)
        {
            if (Guid.TryParse(User.FindFirst("sub")?.Value, out var userId)) cart.UserId = userId;
            return await Update(
                request: new CartUpdateRequest(cart),
                notification: new CartUpdateNotification()).ConfigureAwait(false);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] CartModel cart)
        {
            if (Guid.TryParse(User.FindFirst("sub")?.Value, out var userId)) cart.UserId = userId;
            return await Create(
                request: new CartCreateRequest(cart),
                notification: new CartCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Delete(
                request: new CartDeleteRequest(keyValues[0]),
                notification: new CartDeleteNotification()).ConfigureAwait(false);
        }
    }
}
