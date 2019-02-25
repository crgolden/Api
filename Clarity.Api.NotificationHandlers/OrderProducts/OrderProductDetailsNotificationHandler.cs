namespace Clarity.Api.OrderProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderProductDetailsNotificationHandler : DetailsNotificationHandler<OrderProductDetailsNotification, OrderProductModel>
    {
        public OrderProductDetailsNotificationHandler(ILogger<OrderProductDetailsNotificationHandler> logger) : base(logger)
        {
        }
    }
}
