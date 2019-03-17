namespace Clarity.Api.CartProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartProductUpdateNotificationHandler : UpdateNotificationHandler<CartProductUpdateNotification, CartProductModel>
    {
        public CartProductUpdateNotificationHandler(ILogger<CartProductUpdateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
