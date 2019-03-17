namespace Clarity.Api.OrderProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderProductDeleteRangeNotificationHandler : DeleteRangeNotificationHandler<OrderProductDeleteRangeNotification>
    {
        public OrderProductDeleteRangeNotificationHandler(ILogger<OrderProductDeleteRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
