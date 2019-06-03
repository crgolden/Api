namespace crgolden.Api.Orders
{
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderDeleteRequestHandler : DeleteRequestHandler<OrderDeleteRequest, Order>
    {
        public OrderDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override Task<object[][]> Handle(OrderDeleteRequest request, CancellationToken token)
        {
            return Task.FromResult(new object[0][]);
        }
    }
}
