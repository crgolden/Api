namespace Clarity.Api.Addresses
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;

    public class AddressValidateRequestHandler : IRequestHandler<AddressValidateRequest, bool>
    {
        private readonly IAddressService _service;

        public AddressValidateRequestHandler(IAddressService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(AddressValidateRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _service.ValidateUsAddressAsync(request.Model, cancellationToken);
        }
    }
}
