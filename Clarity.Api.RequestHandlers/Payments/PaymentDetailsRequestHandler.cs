namespace Clarity.Api.Payments
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class PaymentDetailsRequestHandler : DetailsRequestHandler<PaymentDetailsRequest, Payment, PaymentModel>
    {
        public PaymentDetailsRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<PaymentModel> Handle(PaymentDetailsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var payments = Context.Set<Payment>().AsNoTracking();
            if (request.UserId.HasValue) payments = payments.Where(x => x.UserId == request.UserId.Value);
            var payment = await payments
                .SingleOrDefaultAsync(x => x.Id == request.PaymentId, cancellationToken)
                .ConfigureAwait(false);
            return Mapper.Map<PaymentModel>(payment);
        }
    }
}
