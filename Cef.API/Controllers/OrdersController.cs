namespace Cef.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Core.Controllers;
    using Core.Interfaces;
    using IdentityModel;
    using Kendo.Mvc;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;

    public class OrdersController : BaseModelController<Order>
    {
        public OrdersController(IModelService<Order> service, ILogger<OrdersController> logger)
            : base(service, logger)
        {
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            if (User.IsInRole("Admin")) return await base.Index(request);
            var userIdFilter = new FilterDescriptor(
                member: "userId",
                filterOperator: FilterOperator.IsEqualTo,
                filterValue: User.FindFirstValue(JwtClaimTypes.Subject));
            if (request != null)
            {
                request.Filters = request.Filters ?? new List<IFilterDescriptor>();
                var filter = request.Filters
                    .Cast<FilterDescriptor>()
                    .FirstOrDefault(x => x.Member.Equals(userIdFilter.Member));
                if (filter != null)
                {
                    if ($"{filter.Value}" != $"{userIdFilter.Value}")
                    {
                        filter.Value = userIdFilter.Value;
                    }

                    if (filter.Operator != userIdFilter.Operator)
                    {
                        filter.Operator = userIdFilter.Operator;
                    }
                }
                else
                {
                    request.Filters.Add(userIdFilter);
                }

                return await base.Index(request);
            }

            if (!User.IsInRole("User")) return Unauthorized();
            return await base.Index(new DataSourceRequest
            {
                Filters = new List<IFilterDescriptor> {userIdFilter}
            });
        }

        [HttpGet("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromRoute] Guid id)
        {
            if (!Guid.TryParse(User.FindFirstValue(JwtClaimTypes.Subject), out var userId) ||
                userId.Equals(Guid.Empty))
            {
                return Unauthorized();
            }

            var order = await Service.Details(id);
            if (order == null)
            {
                return BadRequest(id);
            }

            if (!userId.Equals(order.UserId) && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            return Ok(order);
        }

        [HttpPut("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] Order model)
        {
            return await base.Edit(id, model);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] Order model)
        {
            return await base.Create(model);
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
