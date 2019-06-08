namespace crgolden.Api.Orders
{
    using System;
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
            while (string.IsNullOrEmpty(order.Number))
            {
                order.Number = $"{Guid.NewGuid().GetHashCode():x8}";
                if (await Context.Set<Order>()
                    .AnyAsync(x => x.Number == order.Number, token)
                    .ConfigureAwait(false)) order.Number = null;
            }

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
