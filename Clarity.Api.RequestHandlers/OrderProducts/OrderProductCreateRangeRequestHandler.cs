namespace Clarity.Api.OrderProducts
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductCreateRangeRequestHandler
        : CreateRangeRequestHandler<OrderProductCreateRangeRequest, IEnumerable<OrderProduct>, OrderProduct>
    {
        public OrderProductCreateRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<OrderProduct>> Handle(OrderProductCreateRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
