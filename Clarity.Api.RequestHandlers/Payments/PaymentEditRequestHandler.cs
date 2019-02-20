namespace Clarity.Api.Payments
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class PaymentEditRequestHandler : EditRequestHandler<PaymentEditRequest, Payment>
    {
        private readonly IPaymentService _paymentService;

        public PaymentEditRequestHandler(DbContext context, IPaymentService paymentService) : base(context)
        {
            _paymentService = paymentService;
        }

        public override async Task<Unit> Handle(PaymentEditRequest request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Entity.ChargeId) && !string.IsNullOrEmpty(request.Entity.Description))
            {
                await _paymentService.UpdateAsync(request.Entity.ChargeId, request.Entity.Description).ConfigureAwait(false);
            }

            return await base.Handle(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
