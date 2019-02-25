namespace Clarity.Api.OrderProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderProductEditNotificationHandler : EditNotificationHandler<OrderProductEditNotification, OrderProductModel>
    {
        public OrderProductEditNotificationHandler(ILogger<OrderProductEditNotificationHandler> logger) : base(logger)
        {
        }
    }
}
