namespace crgolden.Api.Orders
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderReadNotificationHandler : ReadNotificationHandler<OrderReadNotification, OrderModel>
    {
        public OrderReadNotificationHandler(ILogger<OrderReadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
