namespace Clarity.Api.OrderProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductEditRequestHandler : EditRequestHandler<OrderProductEditRequest, OrderProduct, OrderProductModel>
    {
        public OrderProductEditRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<Unit> Handle(OrderProductEditRequest request, CancellationToken token)
        {
            var order = await Context
                .FindAsync<Order>(new object[] { request.Model.OrderId }, token)
                .ConfigureAwait(false);
            var orderProduct = await Context
                .FindAsync<OrderProduct>(new object[] { request.Model.OrderId, request.Model.ProductId }, token)
                .ConfigureAwait(false);
            var product = await Context
                .FindAsync<Product>(new object[] { request.Model.ProductId }, token)
                .ConfigureAwait(false);
            order.Total -= orderProduct.Quantity * product.UnitPrice;
            order.Total += request.Model.Quantity * product.UnitPrice;
            Context.Entry(orderProduct).State = EntityState.Detached;
            return await base.Handle(request, token);
        }
    }
}
