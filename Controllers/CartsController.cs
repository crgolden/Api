namespace crgolden.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Carts;
    using Abstractions.Controllers;
    using Shared;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CartsController : ClassController<Cart, CartModel, Guid>
    {
        public CartsController(IMediator mediator, IMemoryCache cache, IOptions<CacheOptions> cacheOptions)
            : base(mediator, cache, cacheOptions)
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

        protected override async Task<IActionResult> Read<TRequest, TNotification>(TRequest request, TNotification notification)
        {
            using (var tokenSource = new CancellationTokenSource())
            {
                try
                {
                    notification.KeyValues = request.KeyValues;
                    notification.EventId = EventIds.ReadStart;
                    await Mediator.Publish(notification, tokenSource.Token).ConfigureAwait(false);

                    notification.Model = await Mediator.Send(request, tokenSource.Token).ConfigureAwait(false);
                    if (notification.Model == null)
                    {
                        notification.EventId = EventIds.ReadNotFound;
                        await Mediator.Publish(notification, tokenSource.Token).ConfigureAwait(false);
                        return NotFound(request.KeyValues);
                    }

                    notification.EventId = EventIds.ReadEnd;
                    await Mediator.Publish(notification, tokenSource.Token).ConfigureAwait(false);
                    return Ok(notification.Model);
                }
                catch (Exception e)
                {
                    tokenSource.Cancel();
                    notification.Exception = e;
                    notification.EventId = EventIds.ReadError;
                    await Mediator.Publish(notification, CancellationToken.None).ConfigureAwait(false);
                    return BadRequest(request.KeyValues);
                }
            }
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
