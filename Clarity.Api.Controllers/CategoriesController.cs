namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Categories;
    using Core;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CategoriesController : EntitiesController<Category, CategoryModel, Guid>
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request)
        {
            return await Index(
                request: new CategoryIndexRequest(ModelState, request),
                notification: new CategoryIndexNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await Details(
                request: new CategoryDetailsRequest(ids[0]),
                notification: new CategoryDetailsNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] CategoryModel category)
        {
            return await Edit(
                request: new CategoryEditRequest(category),
                notification: new CategoryEditNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<CategoryModel> categories)
        {
            return await EditRange(
                request: new CategoryEditRangeRequest(categories),
                notification: new CategoryEditRangeNotification()).ConfigureAwait(false);
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

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<CategoryModel> categories)
        {
            return await CreateRange(
                request: new CategoryCreateRangeRequest(categories),
                notification: new CategoryCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await Delete(
                request: new CategoryDeleteRequest(ids[0]),
                notification: new CategoryDeleteNotification()).ConfigureAwait(false);
        }
    }
}
