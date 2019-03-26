namespace Clarity.Api.Orders
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderCreateRequestHandler : CreateRequestHandler<OrderCreateRequest, Order, OrderModel>
    {
        public OrderCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<(OrderModel, object[])> Handle(OrderCreateRequest request, CancellationToken token)
        {
            var order = Mapper.Map<Order>(request.Model);
            Context.Add(order);
            var cart = await Context.Set<Cart>()
                .Include(x => x.CartProducts)
                .SingleOrDefaultAsync(x => x.UserId == request.Model.UserId, token)
                .ConfigureAwait(false);
            if (cart != null) Context.RemoveRange(cart.CartProducts);
            await Context.SaveChangesAsync(token).ConfigureAwait(false);
            return (Mapper.Map<OrderModel>(order), new object[]{ order.Id });
        }
    }
}
