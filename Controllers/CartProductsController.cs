//namespace crgolden.Api
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Net;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using CartProducts;
//    using Abstractions.Controllers;
//    using Shared;
//    using MediatR;
//    using Microsoft.AspNet.OData.Query;
//    using Microsoft.AspNetCore.Authorization;
//    using Microsoft.AspNetCore.Mvc;
//    using Microsoft.Extensions.Caching.Memory;
//    using Microsoft.Extensions.Options;

//    [Authorize(AuthenticationSchemes = "Bearer")]
//    public class CartProductsController : RangedClassController<CartProduct, CartProductModel, Guid>
//    {
//        public CartProductsController(IMediator mediator, IMemoryCache cache, IOptions<CacheOptions> cacheOptions)
//            : base(mediator, cache, cacheOptions)
//        {
//        }

//        [ApiExplorerSettings(IgnoreApi = true)]
//        [HttpGet]
//        [AllowAnonymous]
//        [ProducesResponseType(typeof(IEnumerable<CartProduct>), (int)HttpStatusCode.OK)]
//        public override async Task<IActionResult> List(ODataQueryOptions<CartProductModel> options)
//        {
//            return await List(
//                request: User.IsInRole("Admin")
//                    ? new CartProductListRequest(options)
//                    {
//                        UserId = Guid.Parse(User.FindFirst("sub").Value)
//                    }
//                    : new CartProductListRequest(options),
//                notification: new CartProductListNotification()).ConfigureAwait(false);
//        }

//        protected override async Task<IActionResult> List<TRequest, TNotification>(TRequest request, TNotification notification)
//        {
//            using (var tokenSource = new CancellationTokenSource())
//            {
//                try
//                {
//                    notification.Options = request.Options;
//                    notification.EventId = EventIds.ListStart;
//                    await Mediator.Publish(notification, tokenSource.Token).ConfigureAwait(false);

//                    notification.Result = await Mediator.Send(request, tokenSource.Token).ConfigureAwait(false);
//                    notification.EventId = EventIds.ListEnd;
//                    await Mediator.Publish(notification, tokenSource.Token).ConfigureAwait(false);
//                    return Ok(notification.Result);
//                }
//                catch (Exception e)
//                {
//                    tokenSource.Cancel();
//                    notification.Exception = e;
//                    notification.EventId = EventIds.ListError;
//                    await Mediator.Publish(notification, CancellationToken.None).ConfigureAwait(false);
//                    return BadRequest(request);
//                }
//            }
//        }

//        [ApiExplorerSettings(IgnoreApi = true)]
//        [HttpGet]
//        [Authorize(Roles = "Admin")]
//        [ProducesResponseType(typeof(CartProduct), (int)HttpStatusCode.OK)]
//        public override async Task<IActionResult> Read([FromQuery] Guid[] keyValues)
//        {
//            if (keyValues.Length != 2) return BadRequest(keyValues);
//            return await Read(
//                request: new CartProductReadRequest(keyValues[0], keyValues[1]),
//                notification: new CartProductReadNotification()).ConfigureAwait(false);
//        }

//        [ApiExplorerSettings(IgnoreApi = true)]
//        [HttpGet]
//        [Authorize(Roles = "Admin")]
//        [ProducesResponseType(typeof(CartProduct[]), (int)HttpStatusCode.OK)]
//        public override async Task<IActionResult> ReadRange([FromQuery] Guid[][] keyValues)
//        {
//            return await ReadRange(
//                request: new CartProductReadRangeRequest(keyValues),
//                notification: new CartProductReadRangeNotification()).ConfigureAwait(false);
//        }

//        [HttpPut]
//        [AllowAnonymous]
//        [ProducesResponseType((int)HttpStatusCode.NoContent)]
//        public override async Task<IActionResult> Update([FromBody] CartProductModel cartProduct)
//        {
//            return await Update(
//                request: new CartProductUpdateRequest(cartProduct),
//                notification: new CartProductUpdateNotification()).ConfigureAwait(false);
//        }

//        [ApiExplorerSettings(IgnoreApi = true)]
//        [HttpPut]
//        [Authorize(Roles = "Admin")]
//        [ProducesResponseType((int)HttpStatusCode.NoContent)]
//        public override async Task<IActionResult> UpdateRange([FromBody] CartProductModel[] cartProducts)
//        {
//            return await UpdateRange(
//                request: new CartProductUpdateRangeRequest(cartProducts),
//                notification: new CartProductUpdateRangeNotification()).ConfigureAwait(false);
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [ProducesResponseType(typeof(CartProduct), (int)HttpStatusCode.OK)]
//        public override async Task<IActionResult> Create([FromBody] CartProductModel cartProduct)
//        {
//            return await Create(
//                request: new CartProductCreateRequest(cartProduct),
//                notification: new CartProductCreateNotification()).ConfigureAwait(false);
//        }

//        [ApiExplorerSettings(IgnoreApi = true)]
//        [HttpPost]
//        [Authorize(Roles = "Admin")]
//        [ProducesResponseType(typeof(CartProduct[]), (int)HttpStatusCode.NoContent)]
//        public override async Task<IActionResult> CreateRange([FromBody] CartProductModel[] cartProducts)
//        {
//            return await CreateRange(
//                request: new CartProductCreateRangeRequest(cartProducts),
//                notification: new CartProductCreateRangeNotification()).ConfigureAwait(false);
//        }

//        [HttpDelete]
//        [AllowAnonymous]
//        [ProducesResponseType((int)HttpStatusCode.NoContent)]
//        public override async Task<IActionResult> Delete([FromQuery] Guid[] keyValues)
//        {
//            if (keyValues.Length != 2) return BadRequest(keyValues);
//            return await Delete(
//                request: new CartProductDeleteRequest(keyValues[0], keyValues[1]),
//                notification: new CartProductDeleteNotification()).ConfigureAwait(false);
//        }

//        [ApiExplorerSettings(IgnoreApi = true)]
//        [HttpDelete]
//        [AllowAnonymous]
//        [ProducesResponseType((int)HttpStatusCode.NoContent)]
//        public override async Task<IActionResult> DeleteRange([FromQuery] Guid[][] keyValues)
//        {
//            return await DeleteRange(
//                request: new CartProductDeleteRangeRequest(keyValues),
//                notification: new CartProductDeleteRangeNotification()).ConfigureAwait(false);
//        }
//    }
//}
