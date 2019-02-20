namespace Clarity.Api.Addresses
{
    using Core;
    using MediatR;

    public class AddressValidateRequestHandler : RequestHandler<AddressValidateRequest, bool>
    {
        private readonly IAddressService _service;

        public AddressValidateRequestHandler(IAddressService service)
        {
            _service = service;
        }

        protected override bool Handle(AddressValidateRequest request)
        {
            return _service.ValidateUsAddress(request.Address);
        }
    }
}
