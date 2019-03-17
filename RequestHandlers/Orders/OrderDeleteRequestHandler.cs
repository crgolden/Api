namespace Clarity.Api.Orders
{
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class OrderDeleteRequestHandler : DeleteRequestHandler<OrderDeleteRequest, Order>
    {
        public OrderDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override Task<Unit> Handle(OrderDeleteRequest request, CancellationToken token)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}
