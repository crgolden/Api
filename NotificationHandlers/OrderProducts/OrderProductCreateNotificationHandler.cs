namespace crgolden.Api.OrderProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderProductCreateNotificationHandler : CreateNotificationHandler<OrderProductCreateNotification, OrderProductModel>
    {
        public OrderProductCreateNotificationHandler(ILogger<OrderProductCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
