namespace Clarity.Api.OrderProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderProductCreateNotificationHandler : CreateNotificationHandler<OrderProductCreateNotification, OrderProductModel>
    {
        public OrderProductCreateNotificationHandler(ILogger<OrderProductCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
