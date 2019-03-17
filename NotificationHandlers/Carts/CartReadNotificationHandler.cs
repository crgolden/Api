namespace Clarity.Api.Carts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartReadNotificationHandler : ReadNotificationHandler<CartReadNotification, CartModel>
    {
        public CartReadNotificationHandler(ILogger<CartReadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
