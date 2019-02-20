namespace Clarity.Api.Payments
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class PaymentEditRangeRequestHandler : EditRangeRequestHandler<PaymentEditRangeRequest, Payment>
    {
        public PaymentEditRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(PaymentEditRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
