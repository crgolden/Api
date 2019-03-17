namespace Clarity.Api.CartProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartProductReadNotificationHandler : ReadNotificationHandler<CartProductReadNotification, CartProductModel>
    {
        public CartProductReadNotificationHandler(ILogger<CartProductReadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
