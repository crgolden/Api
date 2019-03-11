namespace Clarity.Api.Addresses
{
    using Core;

    public class AddressValidationRequestHandler : ValidationRequestHandler<AddressValidationRequest, Address>
    {
        public AddressValidationRequestHandler(IValidationService<Address> validationService) : base(validationService)
        {
        }
    }
}
