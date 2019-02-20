namespace Clarity.Api.OrderProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductCreateRequestHandler : CreateRequestHandler<OrderProductCreateRequest, OrderProduct>
    {
        public OrderProductCreateRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<OrderProduct> Handle(OrderProductCreateRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
