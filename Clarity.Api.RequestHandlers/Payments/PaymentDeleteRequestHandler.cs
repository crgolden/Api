namespace Clarity.Api.Payments
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class PaymentDeleteRequestHandler : DeleteRequestHandler<PaymentDeleteRequest, Payment>
    {
        public PaymentDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(PaymentDeleteRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
