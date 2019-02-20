namespace Clarity.Api.Orders
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderCreateRangeRequestHandler
        : CreateRangeRequestHandler<OrderCreateRangeRequest, IEnumerable<Order>, Order>
    {
        public OrderCreateRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Order>> Handle(OrderCreateRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
