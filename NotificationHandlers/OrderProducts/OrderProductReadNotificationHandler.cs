namespace Clarity.Api.OrderProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderProductReadNotificationHandler : ReadNotificationHandler<OrderProductReadNotification, OrderProductModel>
    {
        public OrderProductReadNotificationHandler(ILogger<OrderProductReadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
