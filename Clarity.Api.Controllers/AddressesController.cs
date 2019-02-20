namespace Clarity.Api
{
    using System;
    using Addresses;
    using Core;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Produces("application/json")]
    [Route("v1/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AddressesController : ControllerBase
    {
        private readonly ILogger<AddressesController> _logger;
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator, ILogger<AddressesController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult Validate([FromBody] Address address)
        {
            try
            {
                _logger.LogInformation(
                    eventId: new EventId((int)EventIds.ValidateStart, $"{EventIds.ValidateStart}"),
                    message: "Validating address {Address} at {Time}",
                    args: new object[] { address, DateTime.UtcNow });
                var validateRequest = new AddressValidateRequest(address);
                var valid = _mediator.Send(validateRequest);
                _logger.LogInformation(
                    eventId: new EventId((int)EventIds.ValidateEnd, $"{EventIds.ValidateEnd}"),
                    message: "Validated address {Address} at {Time}",
                    args: new object[] { address, DateTime.UtcNow });
                return Ok(valid);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    eventId: new EventId((int)EventIds.ValidateError, $"{EventIds.ValidateError}"), 
                    exception: e,
                    message: "Error validating address {Address} at {Time}",
                    args: new object[] { address, DateTime.UtcNow });
                return Ok(true);
            }
        }
    }
}
