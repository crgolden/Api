namespace crgolden.Api.OrderProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderProductCreateRangeNotificationHandler : CreateRangeNotificationHandler<OrderProductCreateRangeNotification, OrderProductModel>
    {
        public OrderProductCreateRangeNotificationHandler(ILogger<OrderProductCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
