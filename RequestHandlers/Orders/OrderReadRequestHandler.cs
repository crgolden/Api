namespace crgolden.Api.Orders
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderReadRequestHandler : ReadRequestHandler<OrderReadRequest, Order, OrderModel>
    {
        public OrderReadRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<OrderModel> Handle(OrderReadRequest request, CancellationToken token)
        {
            var orders = Context.Set<Order>().AsNoTracking();
            if (request.UserId.HasValue) orders = orders.Where(x => x.UserId == request.UserId.Value);
            var order = await orders
                .SingleOrDefaultAsync(x => x.Id == request.OrderId, token)
                .ConfigureAwait(false);
            return Mapper.Map<OrderModel>(order);
        }
    }
}
