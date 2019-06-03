namespace crgolden.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Categories;
    using Abstractions.Controllers;
    using Shared;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CategoriesController : ClassController<Category, CategoryModel, Guid>
    {
        public CategoriesController(IMediator mediator, IMemoryCache cache, IOptions<CacheOptions> cacheOptions)
            : base(mediator, cache, cacheOptions)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> List([DataSourceRequest] DataSourceRequest request)
        {
            return await List(
                request: new CategoryListRequest(ModelState, request),
                notification: new CategoryListNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Read([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Read(
                request: new CategoryReadRequest(keyValues[0]),
                notification: new CategoryReadNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Update([FromBody] CategoryModel category)
        {
            return await Update(
                request: new CategoryUpdateRequest(category),
                notification: new CategoryUpdateNotification()).ConfigureAwait(false);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] CategoryModel category)
        {
            return await Create(
                request: new CategoryCreateRequest(category),
                notification: new CategoryCreateNotification()).ConfigureAwait(false);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Delete(
                request: new CategoryDeleteRequest(keyValues[0]),
                notification: new CategoryDeleteNotification()).ConfigureAwait(false);
        }
    }
}
