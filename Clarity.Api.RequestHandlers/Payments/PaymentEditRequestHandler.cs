namespace Clarity.Api.Payments
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class PaymentEditRequestHandler : EditRequestHandler<PaymentEditRequest, Payment, PaymentModel>
    {
        private readonly IPaymentService _paymentService;

        public PaymentEditRequestHandler(
            DbContext context,
            IMapper mapper,
            IPaymentService paymentService) : base(context, mapper)
        {
            _paymentService = paymentService;
        }

        public override async Task<Unit> Handle(PaymentEditRequest request, CancellationToken token)
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
