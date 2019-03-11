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
    using Orders;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrdersController : EntitiesController<Order, OrderModel, Guid>
    {
        public OrdersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request)
        {
            return await Index(
                request: new OrderIndexRequest(ModelState, request)
                {
                    UserId = User.IsInRole("Admin")
                        ? (Guid?)null
                        : Guid.Parse(User.FindFirst("sub").Value)
                },
                notification: new OrderIndexNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await Details(
                request: User.IsInRole("Admin")
                    ? new OrderDetailsRequest(ids[0])
                    : new OrderDetailsRequest(ids[0])
                    {
                        UserId = Guid.Parse(User.FindFirst("sub").Value)
                    },
                notification: new OrderDetailsNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] OrderModel order)
        {
            return await Edit(
                request: new OrderEditRequest(order),
                notification: new OrderEditNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<OrderModel> orders)
        {
            return await EditRange(
                request: new OrderEditRangeRequest(orders),
                notification: new OrderEditRangeNotification()).ConfigureAwait(false);
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
        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<OrderModel> orders)
        {
            return await CreateRange(
                request: new OrderCreateRangeRequest(orders),
                notification: new OrderCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await Delete(
                request: new OrderDeleteRequest(ids[0]),
                notification: new OrderDeleteNotification()).ConfigureAwait(false);
        }
    }
}
