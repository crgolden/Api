namespace Clarity.Api.Orders
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;

    public class OrderListRequestHandler : ListRequestHandler<OrderListRequest, Order, OrderModel>
    {
        public OrderListRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<DataSourceResult> Handle(OrderListRequest request, CancellationToken token)
        {
            var orders = request.UserId.HasValue
                ? Context.Set<Order>().Where(x => x.UserId == request.UserId.Value)
                : Context.Set<Order>();
            return await Mapper
                .ProjectTo<OrderModel>(orders.AsNoTracking())
                .ToDataSourceResultAsync(request.Request, request.ModelState)
                .ConfigureAwait(false);
        }
    }
}
