namespace crgolden.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Abstractions.Controllers;
    using Shared;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;
    using OrderProducts;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderProductsController : RangedClassController<OrderProduct, OrderProductModel, Guid>
    {
        public OrderProductsController(IMediator mediator, IMemoryCache cache, IOptions<CacheOptions> cacheOptions)
            : base(mediator, cache, cacheOptions)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(IEnumerable<OrderProduct>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> List([DataSourceRequest] DataSourceRequest request)
        {
            return await List(
                request: User.IsInRole("Admin")
                    ? new OrderProductListRequest(ModelState, request)
                    : new OrderProductListRequest(ModelState, request)
                    {
                        UserId =  Guid.Parse(User.FindFirst("sub").Value)
                    },
                notification: new OrderProductListNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(OrderProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Read([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 2) return BadRequest(keyValues);
            return await Read(
                request: new OrderProductReadRequest(keyValues[0], keyValues[1]),
                notification: new OrderProductReadNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(OrderProduct[]), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> ReadRange([FromQuery] Guid[][] keyValues)
        {
            return await ReadRange(
                request: new OrderProductReadRangeRequest(keyValues),
                notification: new OrderProductReadRangeNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Update([FromBody] OrderProductModel orderProduct)
        {
            return await Update(
                request: new OrderProductUpdateRequest(orderProduct),
                notification: new OrderProductUpdateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> UpdateRange([FromBody] OrderProductModel[] orderProducts)
        {
            return await UpdateRange(
                request: new OrderProductUpdateRangeRequest(orderProducts),
                notification: new OrderProductUpdateRangeNotification()).ConfigureAwait(false);
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
        [ProducesResponseType(typeof(OrderProduct[]), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] OrderProductModel[] orderProducts)
        {
            return await CreateRange(
                request: new OrderProductCreateRangeRequest(orderProducts),
                notification: new OrderProductCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 2) return BadRequest(keyValues);
            return await Delete(
                request: new OrderProductDeleteRequest(keyValues[0], keyValues[1]),
                notification: new OrderProductDeleteNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> DeleteRange([FromQuery] Guid[][] keyValues)
        {
            return await DeleteRange(
                request: new OrderProductDeleteRangeRequest(keyValues),
                notification: new OrderProductDeleteRangeNotification()).ConfigureAwait(false);
        }
    }
}
