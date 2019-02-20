namespace Clarity.Api.OrderProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductIndexRequestHandler : IndexRequestHandler<OrderProductIndexRequest, OrderProduct>
    {
        public OrderProductIndexRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<DataSourceResult> Handle(OrderProductIndexRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
