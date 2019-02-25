namespace Clarity.Api.OrderProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderProductEditRangeNotificationHandler : EditRangeNotificationHandler<OrderProductEditRangeNotification, OrderProductModel>
    {
        public OrderProductEditRangeNotificationHandler(ILogger<OrderProductEditRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
