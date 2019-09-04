namespace crgolden.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Abstractions.Controllers;
    using Shared;
    using MediatR;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;
    using Products;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductsController : ControllerBase<Product, ProductModel, Guid>
    {
        public ProductsController(IMediator mediator, IMemoryCache cache, IOptions<CacheOptions> cacheOptions)
            : base(mediator, cache, cacheOptions)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> List(ODataQueryOptions<ProductModel> options)
        {
            return await List(
                request: new ProductListRequest(options)
                {
                    Active = !User.IsInRole("Admin")
                },
                notification: new ProductListNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [AllowAnonymous]
        [EnableQuery]
        [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
        public override async Task<IActionResult> Read([FromODataUri] params Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Read(
                request: new ProductReadRequest(keyValues[0])
                {
                    Active = !User.IsInRole("Admin")
                },
                notification: new ProductReadNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Update([FromBody] ProductModel product)
        {
            return await Update(
                request: new ProductUpdateRequest(product),
                notification: new ProductUpdateNotification()).ConfigureAwait(false);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] ProductModel product)
        {
            return await Create(
                request: new ProductCreateRequest(product),
                notification: new ProductCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Delete(
                request: new ProductDeleteRequest(keyValues[0]),
                notification: new ProductDeleteNotification()).ConfigureAwait(false);
        }
    }
}
