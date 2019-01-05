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

    [Produces("application/json")]
    [Route("v1/[controller]/[action]")]
    [ApiController]
    public class PaymentsController : BaseModelController<Payment>
    {
        public PaymentsController(IModelService<Payment> service, ILogger<PaymentsController> logger)
            : base(service, logger)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<Payment>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            return await base.Index(request);
        }

        [HttpGet("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
        [ProducesResponseType(typeof(Payment), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromRoute] Guid id)
        {
            if (!Guid.TryParse(User.FindFirstValue(JwtClaimTypes.Subject), out var userId) ||
                userId.Equals(Guid.Empty))
            {
                return Unauthorized();
            }

            var payment = await Service.Details(id);
            if (payment == null)
            {
                return BadRequest(id);
            }

            if (!userId.Equals(payment.UserId) && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            return Ok(payment);
        }

        [HttpPut("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] Payment model)
        {
            return await base.Edit(id, model);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] List<Payment> models)
        {
            return await base.EditRange(models);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(Payment), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] Payment model)
        {
            return await base.Create(model);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(List<Payment>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] List<Payment> models)
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
