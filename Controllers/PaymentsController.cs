namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Abstractions.Controllers;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;
    using Payments;
    using Shared;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PaymentsController : ClassController<Payment, PaymentModel, Guid>
    {
        public PaymentsController(IMediator mediator, IMemoryCache cache, IOptions<CacheOptions> cacheOptions)
            : base(mediator, cache, cacheOptions)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(IEnumerable<Payment>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> List([DataSourceRequest] DataSourceRequest request)
        {
            return await List(
                request: User.IsInRole("Admin")
                    ? new PaymentListRequest(ModelState, request)
                    : new PaymentListRequest(ModelState, request, Guid.Parse(User.FindFirst("sub").Value)),
                notification: new PaymentListNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Payment), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Read([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Read(
                request: new PaymentReadRequest(keyValues[0], Guid.Parse(User.FindFirst("sub").Value)),
                notification: new PaymentReadNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Update([FromBody] PaymentModel payment)
        {
            return await Update(
                request: new PaymentUpdateRequest(payment),
                notification: new PaymentUpdateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Payment), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] PaymentModel payment)
        {
            if (User.HasClaim(x => x.Type == "customer_code"))
            {
                payment.CustomerCode = User.FindFirst("customer_code").Value;
            }

            return await Create(
                request: new PaymentCreateRequest(payment)
                {
                    UserId = Guid.Parse(User.FindFirst("sub").Value),
                    Email = User.FindFirst("email").Value
                },
                notification: new PaymentCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] keyValues)
        {
            if (keyValues.Length != 1) return BadRequest(keyValues);
            return await Delete(
                request: new PaymentDeleteRequest(keyValues[0]),
                notification: new PaymentDeleteNotification()).ConfigureAwait(false);
        }
    }
}
