namespace Clarity.Api.CartProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartProductEditNotificationHandler : EditNotificationHandler<CartProductEditNotification, CartProductModel>
    {
        public CartProductEditNotificationHandler(ILogger<CartProductEditNotificationHandler> logger) : base(logger)
        {
        }
    }
}
