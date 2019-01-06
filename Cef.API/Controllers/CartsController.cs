namespace Cef.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
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

    public class CartsController : BaseModelController<Cart>
    {
        public CartsController(IModelService<Cart> service, ILogger<CartsController> logger)
            : base(service, logger)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<Cart>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            return await base.Index(request);
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromRoute] Guid id)
        {
            var cart = await Service.Details(id);
            if (cart?.UserId == null &&
                Guid.TryParse(User.FindFirstValue(JwtClaimTypes.Subject), out var userId) &&
                !userId.Equals(Guid.Empty))
            {
                if (cart == null)
                {
                    cart = await Service.Details(userId);
                }
                else
                {
                    cart.UserId = userId;
                    await Service.Edit(cart);
                }
            }

            if (cart == null)
            {
                return NotFound(id);
            }

            return Ok(cart);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{id:guid}")]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] Cart model)
        {
            if (!model.UserId.HasValue &&
                Guid.TryParse(User.FindFirstValue(JwtClaimTypes.Subject), out var userId) &&
                !userId.Equals(Guid.Empty))
            {
                model.UserId = userId;
            }

            return await base.Edit(id, model);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] List<Cart> models)
        {
            return await base.EditRange(models);
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] Cart model)
        {
            if (!model.UserId.HasValue &&
                Guid.TryParse(User.FindFirstValue(JwtClaimTypes.Subject), out var userId) &&
                !userId.Equals(Guid.Empty))
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

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(List<Cart>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] List<Cart> models)
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
