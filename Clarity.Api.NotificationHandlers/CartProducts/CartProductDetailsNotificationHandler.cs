namespace Clarity.Api.CartProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartProductDetailsNotificationHandler : DetailsNotificationHandler<CartProductDetailsNotification, CartProductModel>
    {
        public CartProductDetailsNotificationHandler(ILogger<CartProductDetailsNotificationHandler> logger) : base(logger)
        {
        }
    }
}
