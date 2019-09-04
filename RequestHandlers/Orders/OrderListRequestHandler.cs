namespace crgolden.Api.Orders
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderListRequestHandler : ListRequestHandler<OrderListRequest, Order, OrderModel>
    {
        public OrderListRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task<IQueryable<OrderModel>> Handle(OrderListRequest request, CancellationToken token)
        {
            var orders = request.UserId.HasValue
                ? Context.Set<Order>().Where(x => x.UserId == request.UserId.Value)
                : Context.Set<Order>();
            var query = request.Options.ApplyTo(orders.AsNoTracking());
            return Task.FromResult(Mapper.ProjectTo<OrderModel>(query));
        }
    }
}
