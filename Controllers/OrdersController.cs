namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Abstractions.Controllers;
    using Core;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;
    using Orders;
    using Shared;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrdersController : ClassController<Order, OrderModel, Guid>
    {
        public OrdersController(IMediator mediator, IMemoryCache cache, IOptions<CacheOptions> cacheOptions)
            : base(mediator, cache, cacheOptions)
        {
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> List([DataSourceRequest] DataSourceRequest request)
        {
            return await List(
                request: new OrderListRequest(ModelState, request)
                {
                    UserId = User.IsInRole("Admin")
                        ? (Guid?)null
                        : Guid.Parse(User.FindFirst("sub").Value)
                },
                notification: new OrderListNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Read([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Read(
                request: User.IsInRole("Admin")
                    ? new OrderReadRequest(keyValues[0])
                    : new OrderReadRequest(keyValues[0])
                    {
                        UserId = Guid.Parse(User.FindFirst("sub").Value)
                    },
                notification: new OrderReadNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Update([FromBody] OrderModel order)
        {
            return await Update(
                request: new OrderUpdateRequest(order),
                notification: new OrderUpdateNotification()).ConfigureAwait(false);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] OrderModel order)
        {
            order.UserId = Guid.Parse(User.FindFirst("sub").Value);
            return await Create(
                request: new OrderCreateRequest(order),
                notification: new OrderCreateNotification
                {
                    Emails = new [] { User.FindFirst("email").Value },
                    Origin = Request.GetOrigin()
                }).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Delete(
                request: new OrderDeleteRequest(keyValues[0]),
                notification: new OrderDeleteNotification()).ConfigureAwait(false);
        }
    }
}
