namespace Clarity.Api.Payments
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class PaymentCreateRequestHandler : CreateRequestHandler<PaymentCreateRequest, Payment>
    {
        private readonly IPaymentService _paymentService;

        public PaymentCreateRequestHandler(DbContext context, IPaymentService paymentService) : base(context)
        {
            _paymentService = paymentService;
        }

        public override async Task<Payment> Handle(PaymentCreateRequest request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Entity.CustomerCode))
            {
                request.Entity.ChargeId = await _paymentService.CaptureAsync(
                    customerId: request.Entity.CustomerCode,
                    amount: request.Entity.Amount,
                    currency: request.Entity.Currency,
                    description: request.Entity.Description).ConfigureAwait(false);
            }

            return await base.Handle(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
