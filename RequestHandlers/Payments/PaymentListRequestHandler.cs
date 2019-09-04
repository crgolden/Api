namespace crgolden.Api.Payments
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class PaymentListRequestHandler : ListRequestHandler<PaymentListRequest, Payment, PaymentModel>
    {
        public PaymentListRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task<IQueryable<PaymentModel>> Handle(PaymentListRequest request, CancellationToken token)
        {
            var payments = request.UserId.HasValue
                ? Context.Set<Payment>().Where(x => x.UserId == request.UserId.Value)
                : Context.Set<Payment>();
            var query = request.Options.ApplyTo(payments);
            return Task.FromResult(Mapper.ProjectTo<PaymentModel>(query));
        }
    }
}
