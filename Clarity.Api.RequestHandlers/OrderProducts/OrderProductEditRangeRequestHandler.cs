namespace Clarity.Api.OrderProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductEditRangeRequestHandler : EditRangeRequestHandler<OrderProductEditRangeRequest, OrderProduct>
    {
        public OrderProductEditRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(OrderProductEditRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
