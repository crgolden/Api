namespace Cef.API.Controllers
{
    using System.IO;
    using Core;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Options;
    using SmartyStreets;
    using SmartyStreets.USStreetApi;

    [Produces("application/json")]
    [Route("v1/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AddressesController : ControllerBase
    {
        private readonly Client _client;
        private readonly ILogger<AddressesController> _logger;

        public AddressesController(
            IOptions<ValidationOptions> options,
            ILogger<AddressesController> logger)
        {
            _client = new ClientBuilder(
                    authId: options.Value.SmartyStreets.AuthId,
                    authToken: options.Value.SmartyStreets.AuthToken)
                .BuildUsStreetApiClient();
            _logger = logger;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult Validate([FromBody] AddressClaim address)
        {
            try
            {
                var lookup = new Lookup
                {
                    Street = address.StreetAddress,
                    City = address.Locality,
                    State = address.Region,
                    ZipCode = address.PostalCode
                };
                _client.Send(lookup);
                return Ok(lookup.Result.Count > 0);
            }
            catch (SmartyException e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest();
            }
            catch (IOException e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest();
            }
        }
    }
}
