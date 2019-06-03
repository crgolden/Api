namespace crgolden.Api.Payments
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;

    public class PaymentListRequestHandler : ListRequestHandler<PaymentListRequest, Payment, PaymentModel>
    {
        public PaymentListRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<DataSourceResult> Handle(PaymentListRequest request, CancellationToken token)
        {
            var payments = request.UserId.HasValue
                ? Context.Set<Payment>().Where(x => x.UserId == request.UserId.Value)
                : Context.Set<Payment>();
            return await Mapper
                .ProjectTo<PaymentModel>(payments.AsNoTracking())
                .ToDataSourceResultAsync(request.Request, request.ModelState)
                .ConfigureAwait(false);
        }
    }
}
