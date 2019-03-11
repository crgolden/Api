namespace Clarity.Api
{
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
    public class AddressesController : ValidationController<Address>
    {
        public AddressesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public override async Task<IActionResult> Validate([FromBody] Address address)
        {
            return await Validate(
                request: new AddressValidationRequest(address),
                notification: new AddressValidationNotification());
        }
    }
}
