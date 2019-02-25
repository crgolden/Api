namespace Clarity.Api.Orders
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderIndexNotificationHandler : IndexNotificationHandler<OrderIndexNotification>
    {
        public OrderIndexNotificationHandler(ILogger<OrderIndexNotificationHandler> logger) : base(logger)
        {
        }
    }
}
