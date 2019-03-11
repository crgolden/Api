namespace Clarity.Api.Addresses
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class AddressValidationNotificationHandler : ValidateNotificationHandler<AddressValidationNotification, Address>
    {
        public AddressValidationNotificationHandler(ILogger<AddressValidationNotificationHandler> logger) : base(logger)
        {
        }
    }
}
