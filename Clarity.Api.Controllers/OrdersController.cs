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
    public class OrdersController : Controller<Order, OrderModel, Guid>
    {
        public OrdersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request)
        {
            return await base.Index(
                request: new OrderIndexRequest(ModelState, request)
                {
                    UserId = User.IsInRole("Admin") ? null : UserId
                },
                notification: new OrderIndexNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await base.Details(
                request: new OrderDetailsRequest(ids[0])
                {
                    UserId = User.IsInRole("Admin") ? null : UserId
                },
                notification: new OrderDetailsNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] OrderModel order)
        {
            return await base.Edit(
                request: new OrderEditRequest(order),
                notification: new OrderEditNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<OrderModel> orders)
        {
            return await base.EditRange(
                request: new OrderEditRangeRequest(orders),
                notification: new OrderEditRangeNotification()).ConfigureAwait(false);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] OrderModel order)
        {
            return await base.Create(
                request: new OrderCreateRequest(order),
                notification: new OrderCreateNotification
                {
                    UserEmail = UserEmail
                }).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<OrderModel> orders)
        {
            return await base.CreateRange(
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
            return await base.Delete(
                request: new OrderDeleteRequest(ids[0]),
                notification: new OrderDeleteNotification()).ConfigureAwait(false);
        }
    }
}
