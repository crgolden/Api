namespace Clarity.Api.Payments
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class PaymentReadRequestHandler : ReadRequestHandler<PaymentReadRequest, Payment, PaymentModel>
    {
        public PaymentReadRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<PaymentModel> Handle(PaymentReadRequest request, CancellationToken token)
        {
            var payments = Context.Set<Payment>().AsNoTracking();
            if (request.UserId.HasValue) payments = payments.Where(x => x.UserId == request.UserId.Value);
            var payment = await payments
                .SingleOrDefaultAsync(x => x.Id == request.PaymentId, token)
                .ConfigureAwait(false);
            return Mapper.Map<PaymentModel>(payment);
        }
    }
}
