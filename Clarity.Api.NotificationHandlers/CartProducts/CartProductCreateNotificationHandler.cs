namespace Clarity.Api.CartProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartProductCreateNotificationHandler : CreateNotificationHandler<CartProductCreateNotification, CartProductModel>
    {
        public CartProductCreateNotificationHandler(ILogger<CartProductCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
