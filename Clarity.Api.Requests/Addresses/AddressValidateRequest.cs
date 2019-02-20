namespace Clarity.Api.Addresses
{
    using Core;
    using MediatR;

    public class AddressValidateRequest : IRequest<bool>
    {
        public Address Address { get; set; }

        public AddressValidateRequest(Address address)
        {
        }
    }
}
