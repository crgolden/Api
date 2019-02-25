namespace Clarity.Api.OrderProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class OrderProductCreateRangeNotificationHandler : CreateRangeNotificationHandler<OrderProductCreateRangeNotification, OrderProductModel>
    {
        public OrderProductCreateRangeNotificationHandler(ILogger<OrderProductCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
