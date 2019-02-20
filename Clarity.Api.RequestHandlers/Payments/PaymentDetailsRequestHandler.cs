namespace Clarity.Api.Payments
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class PaymentDetailsRequestHandler : DetailsRequestHandler<PaymentDetailsRequest, Payment>
    {
        public PaymentDetailsRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Payment> Handle(PaymentDetailsRequest request, CancellationToken cancellationToken)
        {
            var payments = Context.Set<Payment>().AsNoTracking();
            if (request.UserId.HasValue) payments = payments.Where(x => x.UserId == request.UserId.Value);
            return await payments
                .SingleOrDefaultAsync(x => x.Id == request.PaymentId, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
