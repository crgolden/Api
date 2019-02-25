namespace Clarity.Api.Orders
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderCreateRangeNotificationHandler : CreateRangeNotificationHandler<OrderCreateRangeNotification, OrderModel>
    {
        public OrderCreateRangeNotificationHandler(ILogger<OrderCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
