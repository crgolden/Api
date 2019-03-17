namespace Clarity.Api.Orders
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderUpdateNotificationHandler : UpdateNotificationHandler<OrderUpdateNotification, OrderModel>
    {
        public OrderUpdateNotificationHandler(ILogger<OrderUpdateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
