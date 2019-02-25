namespace Clarity.Api.OrderProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderProductIndexNotificationHandler : IndexNotificationHandler<OrderProductIndexNotification>
    {
        public OrderProductIndexNotificationHandler(ILogger<OrderProductIndexNotificationHandler> logger) : base(logger)
        {
        }
    }
}
