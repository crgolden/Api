namespace crgolden.Api.OrderProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderProductUpdateRangeNotificationHandler : UpdateRangeNotificationHandler<OrderProductUpdateRangeNotification, OrderProductModel>
    {
        public OrderProductUpdateRangeNotificationHandler(ILogger<OrderProductUpdateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
