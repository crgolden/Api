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
    using Microsoft.Extensions.Logging;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CategoriesController : Controller<Category, Guid>
    {
        public CategoriesController(IMediator mediator, ILogger<CategoriesController> logger)
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            var indexRequest = new CategoryIndexRequest(ModelState, request);
            return await base.Index(indexRequest).ConfigureAwait(false);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            var detailsRequest = new CategoryDetailsRequest(ids[0]);
            return await base.Details(detailsRequest).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] Category category)
        {
            var editRequest = new CategoryEditRequest(category);
            return await base.Edit(editRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<Category> categories)
        {
            var editRangeRequest = new CategoryEditRangeRequest(categories);
            return await base.EditRange(editRangeRequest).ConfigureAwait(false);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] Category category)
        {
            var createRequest = new CategoryCreateRequest(category);
            return await base.Create(createRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<Category> categories)
        {
            var creteRangeRequest = new CategoryCreateRangeRequest(categories);
            return await base.CreateRange(creteRangeRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            var deleteRequest = new CategoryDeleteRequest(ids[0]);
            return await base.Delete(deleteRequest).ConfigureAwait(false);
        }
    }
}
