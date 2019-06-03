namespace crgolden.Api.OrderProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderProductListNotificationHandler : ListNotificationHandler<OrderProductListNotification>
    {
        public OrderProductListNotificationHandler(ILogger<OrderProductListNotificationHandler> logger) : base(logger)
        {
        }
    }
}
