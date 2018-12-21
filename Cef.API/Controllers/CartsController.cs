namespace Cef.API.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Core.Controllers;
    using Core.Interfaces;
    using IdentityModel;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;

    [Authorize(AuthenticationSchemes = "api1")]
    public class CartsController : BaseModelController<Cart>
    {
        public CartsController(IModelService<Cart> service, ILogger<CartsController> logger)
            : base(service, logger)
        {
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [AllowAnonymous]
        public override async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] Cart model)
        {
            if (Guid.TryParse(User?.FindFirstValue(JwtClaimTypes.Subject), out var userId))
            {
                model.UserId = userId;
            }

            return await base.Edit(id, model);
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<IActionResult> Create([FromBody] Cart model)
        {
            if (Guid.TryParse(User?.FindFirstValue(JwtClaimTypes.Subject), out var userId))
            {
                model.UserId = userId;
            }

            try
            {
                var cart = await Service.Create(model);
                Response.Cookies.Append("CartId", $"{cart.Id}");
                return Ok(cart);
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return BadRequest(model);
            }
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await base.Delete(id);
        }
    }
}
