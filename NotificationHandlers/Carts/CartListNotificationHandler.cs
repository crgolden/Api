namespace crgolden.Api.Carts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartListNotificationHandler : ListNotificationHandler<CartListNotification>
    {
        public CartListNotificationHandler(ILogger<CartListNotificationHandler> logger) : base(logger)
        {
        }
    }
}
