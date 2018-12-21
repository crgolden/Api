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
    using Relationships;

    [Authorize(AuthenticationSchemes = "api1")]
    public class CartProductsController : BaseRelationshipController<CartProduct, Cart, Product>
    {
        public CartProductsController(IRelationshipService<CartProduct, Cart, Product> service, ILogger<CartProductsController> logger)
            : base(service, logger)
        {
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            return await base.Index(request);
        }

        [HttpGet("{id1:guid}/{id2:guid}")]
        [Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Details([FromRoute] Guid id1, [FromRoute] Guid id2)
        {
            return await base.Details(id1, id2);
        }

        [HttpPut("{id1:guid}/{id2:guid}")]
        [AllowAnonymous]
        public override async Task<IActionResult> Edit([FromRoute] Guid id1, [FromRoute] Guid id2, [FromBody] CartProduct relationship)
        {
            return await base.Edit(id1, id2, relationship);
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<IActionResult> Create([FromBody] CartProduct relationship)
        {
            return await base.Create(relationship);
        }

        [HttpDelete("{id1:guid}/{id2:guid}")]
        [AllowAnonymous]
        public override async Task<IActionResult> Delete([FromRoute] Guid id1, [FromRoute] Guid id2)
        {
            return await base.Delete(id1, id2);
        }
    }
}
