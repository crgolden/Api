namespace Clarity.Api.OrderProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductDeleteRequestHandler : DeleteRequestHandler<OrderProductDeleteRequest, OrderProduct>
    {
        public OrderProductDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override Task<Unit> Handle(OrderProductDeleteRequest request, CancellationToken cancellationToken)
        {   
            return Task.FromResult(Unit.Value);
        }
    }
}
