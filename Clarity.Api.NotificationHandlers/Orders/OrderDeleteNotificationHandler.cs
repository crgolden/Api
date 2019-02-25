namespace Clarity.Api.Orders
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderDeleteNotificationHandler : DeleteNotificationHandler<OrderDeleteNotification>
    {
        public OrderDeleteNotificationHandler(ILogger<OrderDeleteNotificationHandler> logger) : base(logger)
        {
        }

        public override Task Handle(OrderDeleteNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
