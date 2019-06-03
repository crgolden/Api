namespace crgolden.Api.OrderProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderProductUpdateNotificationHandler : UpdateNotificationHandler<OrderProductUpdateNotification, OrderProductModel>
    {
        public OrderProductUpdateNotificationHandler(ILogger<OrderProductUpdateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
