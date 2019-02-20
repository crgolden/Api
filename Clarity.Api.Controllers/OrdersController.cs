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
    using Orders;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrdersController : Controller<Order, Guid>
    {
        public OrdersController(IMediator mediator, ILogger<OrdersController> logger)
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            var indexRequest = new OrderIndexRequest(ModelState, request);
            if (User.IsInRole("Admin"))
            {
                indexRequest.UserId = UserId;
            }

            return await base.Index(indexRequest).ConfigureAwait(false);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            var detailsRequest = new OrderDetailsRequest(ids[0]);
            if (!User.IsInRole("Admin"))
            {
                detailsRequest.UserId = UserId;
            }

            return await base.Details(detailsRequest).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] Order order)
        {
            var editRequest = new OrderEditRequest(order);
            return await base.Edit(editRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<Order> orders)
        {
            var editRangeRequest = new OrderEditRangeRequest(orders);
            return await base.EditRange(editRangeRequest).ConfigureAwait(false);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] Order order)
        {
            var createRequest = new OrderCreateRequest(order);
            if (User.HasClaim(x => x.Type.Equals("customer_code")))
            {
                createRequest.CustomerCode = User.FindFirst("customer_code").Value;
            }
            else
            {
                createRequest.Email = UserEmail;
            }

            return await base.Create(createRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<Order> orders)
        {
            var createRangeRequest = new OrderCreateRangeRequest(orders);
            return await base.CreateRange(createRangeRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            var deleteRequest = new OrderDeleteRequest(ids[0]);
            return await base.Delete(deleteRequest).ConfigureAwait(false);
        }
    }
}
