namespace Clarity.Api.Addresses
{
    using Core;

    public class AddressValidationRequest : ValidationRequest<Address>
    {
        public AddressValidationRequest(Address address) : base(address)
        {
        }
    }
}
