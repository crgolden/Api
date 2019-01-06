namespace Cef.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Core.Controllers;
    using Core.Interfaces;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;

    public class CategoriesController : BaseModelController<Category>
    {
        public CategoriesController(IModelService<Category> service, ILogger<CategoriesController> logger)
            : base(service, logger)
        {
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            return await base.Index(request);
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromRoute] Guid id)
        {
            return await base.Details(id);
        }

        [HttpPut("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] Category model)
        {
            return await base.Edit(id, model);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] List<Category> models)
        {
            return await base.EditRange(models);
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] Category model)
        {
            return await base.Create(model);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(List<Category>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] List<Category> models)
        {
            return await base.CreateRange(models);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await base.Delete(id);
        }
    }
}
