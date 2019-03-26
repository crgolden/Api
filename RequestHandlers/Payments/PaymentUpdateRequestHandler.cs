namespace Clarity.Api.Payments
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Shared;

    public class PaymentUpdateRequestHandler : UpdateRequestHandler<PaymentUpdateRequest, Payment, PaymentModel>
    {
        private readonly IPaymentService _paymentService;

        public PaymentUpdateRequestHandler(
            DbContext context,
            IMapper mapper,
            IPaymentService paymentService) : base(context, mapper)
        {
            _paymentService = paymentService;
        }

        public override async Task<object[]> Handle(PaymentUpdateRequest request, CancellationToken token)
        {
            if (!string.IsNullOrEmpty(request.Model.ChargeId) && !string.IsNullOrEmpty(request.Model.Description))
            {
                await _paymentService.UpdateAsync(
                    chargeId: request.Model.ChargeId,
                    description: request.Model.Description,
                    token: token).ConfigureAwait(false);
            }

            return await base.Handle(request, token).ConfigureAwait(false);
        }
    }
}
