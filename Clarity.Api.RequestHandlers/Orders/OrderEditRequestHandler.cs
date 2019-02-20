namespace Clarity.Api.Orders
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class OrderEditRequestHandler : EditRequestHandler<OrderEditRequest, Order>
    {
        public OrderEditRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(OrderEditRequest request, CancellationToken cancellationToken)
        {
            request.Entity.Total = request.Entity.OrderProducts.Sum(x => x.ExtendedPrice);
            return await base.Handle(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
