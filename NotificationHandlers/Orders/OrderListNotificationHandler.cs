namespace crgolden.Api.Orders
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderListNotificationHandler : ListNotificationHandler<OrderListNotification>
    {
        public OrderListNotificationHandler(ILogger<OrderListNotificationHandler> logger) : base(logger)
        {
        }
    }
}
