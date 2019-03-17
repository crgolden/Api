namespace Clarity.Api.OrderProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderProductReadRangeNotificationHandler : ReadRangeNotificationHandler<OrderProductReadRangeNotification, OrderProductModel>
    {
        public OrderProductReadRangeNotificationHandler(ILogger<OrderProductReadRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
