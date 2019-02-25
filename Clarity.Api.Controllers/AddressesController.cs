namespace Clarity.Api
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Addresses;
    using Core;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("v1/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Validate([FromBody] Address address)
        {
            using (var tokenSource = new CancellationTokenSource())
            {
                var request = new AddressValidateRequest(address);
                var notification = new AddressValidateNotification();
                try
                {
                    notification.Model = request.Model;
                    notification.EventId = EventIds.ValidateStart;
                    await _mediator.Publish(notification, tokenSource.Token).ConfigureAwait(false);

                    notification.Valid = await _mediator.Send(request, tokenSource.Token).ConfigureAwait(false);
                    notification.EventId = EventIds.ValidateEnd;
                    await _mediator.Publish(notification, tokenSource.Token).ConfigureAwait(false);
                    return Ok(notification.Valid);
                }
                catch (Exception e)
                {
                    notification.Exception = e;
                    notification.EventId = EventIds.ValidateError;
                    await _mediator.Publish(notification, tokenSource.Token).ConfigureAwait(false);
                    return Ok(notification.Valid);
                }
            }
        }
    }
}
