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
    using OrderProducts;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderProductsController : EntitiesController<OrderProduct, OrderProductModel, Guid>
    {
        public OrderProductsController(IMediator mediator) : base(mediator)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(IEnumerable<OrderProduct>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request)
        {
            return await Index(
                request: User.IsInRole("Admin")
                    ? new OrderProductIndexRequest(ModelState, request)
                    : new OrderProductIndexRequest(ModelState, request)
                    {
                        UserId =  Guid.Parse(User.FindFirst("sub").Value)
                    },
                notification: new OrderProductIndexNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(OrderProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 2) return BadRequest(ids);
            return await Details(
                request: new OrderProductDetailsRequest(ids[0], ids[1]),
                notification: new OrderProductDetailsNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] OrderProductModel orderProduct)
        {
            return await Edit(
                request: new OrderProductEditRequest(orderProduct),
                notification: new OrderProductEditNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<OrderProductModel> orderProducts)
        {
            return await EditRange(
                request: new OrderProductEditRangeRequest(orderProducts),
                notification: new OrderProductEditRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(OrderProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] OrderProductModel orderProduct)
        {
            return await Create(
                request: new OrderProductCreateRequest(orderProduct),
                notification: new OrderProductCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<OrderProduct>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<OrderProductModel> orderProducts)
        {
            return await CreateRange(
                request: new OrderProductCreateRangeRequest(orderProducts),
                notification: new OrderProductCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 2) return BadRequest(ids);
            return await Delete(
                request: new OrderProductDeleteRequest(ids[0], ids[1]),
                notification: new OrderProductDeleteNotification()).ConfigureAwait(false);
        }
    }
}
