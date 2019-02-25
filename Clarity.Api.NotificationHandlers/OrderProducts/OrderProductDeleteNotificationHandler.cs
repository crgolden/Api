namespace Clarity.Api.OrderProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderProductDeleteNotificationHandler : DeleteNotificationHandler<OrderProductDeleteNotification>
    {
        public OrderProductDeleteNotificationHandler(ILogger<OrderProductDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
