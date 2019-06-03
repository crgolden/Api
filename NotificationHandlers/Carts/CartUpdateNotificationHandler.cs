namespace crgolden.Api.Carts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartUpdateNotificationHandler : UpdateNotificationHandler<CartUpdateNotification, CartModel>
    {
        public CartUpdateNotificationHandler(ILogger<CartUpdateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
