namespace Clarity.Api.Addresses
{
    using Core;
    using MediatR;

    public class AddressValidateRequest : IRequest<bool>
    {
        public readonly Address Model;

        public AddressValidateRequest(Address model)
        {
            Model = model;
        }
    }
}
