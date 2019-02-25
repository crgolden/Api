namespace Clarity.Api.Orders
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderDetailsNotificationHandler : DetailsNotificationHandler<OrderDetailsNotification, OrderModel>
    {
        public OrderDetailsNotificationHandler(ILogger<OrderDetailsNotificationHandler> logger) : base(logger)
        {
        }
    }
}
