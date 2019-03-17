namespace Clarity.Api.OrderProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderProductDeleteNotificationHandler : DeleteNotificationHandler<OrderProductDeleteNotification>
    {
        public OrderProductDeleteNotificationHandler(ILogger<OrderProductDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
