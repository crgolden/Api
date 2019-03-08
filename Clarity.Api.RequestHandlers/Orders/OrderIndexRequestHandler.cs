namespace Clarity.Api.Orders
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;

    public class OrderIndexRequestHandler : IndexRequestHandler<OrderIndexRequest, Order, OrderModel>
    {
        public OrderIndexRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<DataSourceResult> Handle(OrderIndexRequest request, CancellationToken token)
        {
            var orders = request.UserId.HasValue
                ? Context.Set<Order>().Where(x => x.UserId == request.UserId.Value)
                : Context.Set<Order>();
            return await Mapper
                .ProjectTo<OrderModel>(orders)
                .ToDataSourceResultAsync(request.Request, request.ModelState)
                .ConfigureAwait(false);
        }
    }
}
