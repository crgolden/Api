namespace Clarity.Api.OrderProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductDetailsRequestHandler : DetailsRequestHandler<OrderProductDetailsRequest, OrderProduct>
    {
        public OrderProductDetailsRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<OrderProduct> Handle(OrderProductDetailsRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
