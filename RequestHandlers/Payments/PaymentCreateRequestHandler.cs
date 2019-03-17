namespace Clarity.Api.Payments
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Shared;

    public class PaymentCreateRequestHandler : CreateRequestHandler<PaymentCreateRequest, Payment, PaymentModel>
    {
        private readonly IPaymentService _paymentService;

        public PaymentCreateRequestHandler(
            DbContext context,
            IMapper mapper,
            IPaymentService paymentService) : base(context, mapper)
        {
            _paymentService = paymentService;
        }

        public override async Task<PaymentModel> Handle(PaymentCreateRequest request, CancellationToken token)
        {
            if (string.IsNullOrEmpty(request.Model.TokenId)) return null;
            if (string.IsNullOrEmpty(request.Model.CustomerCode) && !string.IsNullOrEmpty(request.Email))
            {
                request.Model.CustomerCode = await _paymentService
                    .CreateCustomerAsync(
                        email: request.Email,
                        tokenId: request.Model.TokenId,
                        token: token)
                    .ConfigureAwait(false);
            }

            if (string.IsNullOrEmpty(request.Model.CustomerCode)) return null;
            request.Model.ChargeId = await _paymentService.CaptureAsync(
                customerId: request.Model.CustomerCode,
                amount: request.Model.Amount,
                currency: request.Model.Currency,
                description: request.Model.Description,
                token: token).ConfigureAwait(false);
            return await base.Handle(request, token).ConfigureAwait(false);
        }
    }
}
