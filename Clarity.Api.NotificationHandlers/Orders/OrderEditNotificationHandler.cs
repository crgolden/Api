namespace Clarity.Api.Orders
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderEditNotificationHandler : EditNotificationHandler<OrderEditNotification, OrderModel>
    {
        public OrderEditNotificationHandler(ILogger<OrderEditNotificationHandler> logger) : base(logger)
        {
        }
    }
}
