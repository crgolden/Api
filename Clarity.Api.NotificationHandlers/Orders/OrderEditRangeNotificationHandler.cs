namespace Clarity.Api.Orders
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderEditRangeNotificationHandler : EditRangeNotificationHandler<OrderEditRangeNotification, OrderModel>
    {
        public OrderEditRangeNotificationHandler(ILogger<OrderEditRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
