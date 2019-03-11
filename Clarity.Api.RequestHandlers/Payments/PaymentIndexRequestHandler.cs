namespace Clarity.Api.Payments
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;

    public class PaymentIndexRequestHandler : IndexRequestHandler<PaymentIndexRequest, Payment, PaymentModel>
    {
        public PaymentIndexRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<DataSourceResult> Handle(PaymentIndexRequest request, CancellationToken token)
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
