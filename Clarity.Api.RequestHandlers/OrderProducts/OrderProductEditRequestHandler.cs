namespace Clarity.Api.OrderProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductEditRequestHandler : EditRequestHandler<OrderProductEditRequest, OrderProduct>
    {
        public OrderProductEditRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(OrderProductEditRequest request, CancellationToken cancellationToken)
        {
            var orderProduct = await Context
                .FindAsync<OrderProduct>(new object[] { request.Entity.OrderId, request.Entity.ProductId }, cancellationToken)
                .ConfigureAwait(false);
            var order = await Context
                .FindAsync<Order>(new object[] { request.Entity.OrderId }, cancellationToken)
                .ConfigureAwait(false);
            if (orderProduct == null || order == null) return Unit.Value;

            order.Total -= orderProduct.ExtendedPrice;
            order.Total += request.Entity.ExtendedPrice;
            Context.Entry(orderProduct).State = EntityState.Detached;

            return await base.Handle(request, cancellationToken);
        }
    }
}
