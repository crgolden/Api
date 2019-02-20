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
    using OrderProducts;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderProductsController : Controller<OrderProduct, Guid>
    {
        public OrderProductsController(IMediator mediator, ILogger<OrderProductsController> logger)
            : base(mediator, logger)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<OrderProduct>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            var indexRequest = new OrderProductIndexRequest(ModelState, request);
            return await base.Index(indexRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(OrderProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 2) return BadRequest(ids);
            var detailsRequest = new OrderProductDetailsRequest(ids[0], ids[1]);
            return await base.Details(detailsRequest).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] OrderProduct orderProduct)
        {
            var editRequest = new OrderProductEditRequest(orderProduct);
            return await base.Edit(editRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<OrderProduct> orderProducts)
        {
            var editRangeRequest = new OrderProductEditRangeRequest(orderProducts);
            return await base.EditRange(editRangeRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(OrderProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] OrderProduct orderProduct)
        {
            var createRequest = new OrderProductCreateRequest(orderProduct);
            return await base.Create(createRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<OrderProduct>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<OrderProduct> orderProducts)
        {
            var createRangeRequest = new OrderProductCreateRangeRequest(orderProducts);
            return await base.CreateRange(createRangeRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 2) return BadRequest(ids);
            var deleteRequest = new OrderProductDeleteRequest(ids[0], ids[1]);
            return await base.Delete(deleteRequest).ConfigureAwait(false);
        }
    }
}
