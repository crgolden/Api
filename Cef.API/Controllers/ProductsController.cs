namespace Cef.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Core.Controllers;
    using Core.Interfaces;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;

    [Authorize(AuthenticationSchemes = "api1")]
    public class ProductsController : BaseModelController<Product>
    {
        public ProductsController(IModelService<Product> service, ILogger<ProductsController> logger)
            : base(service, logger)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            return await base.Index(request);
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public override async Task<IActionResult> Details([FromRoute] Guid id)
        {
            return await base.Details(id);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] Product model)
        {
            return await base.Edit(id, model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Create([FromBody] Product model)
        {
            return await base.Create(model);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await base.Delete(id);
        }
    }
}
