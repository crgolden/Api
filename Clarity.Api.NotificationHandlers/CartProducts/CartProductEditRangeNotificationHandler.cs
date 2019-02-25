namespace Clarity.Api.CartProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartProductEditRangeNotificationHandler : EditRangeNotificationHandler<CartProductEditRangeNotification, CartProductModel>
    {
        public CartProductEditRangeNotificationHandler(ILogger<CartProductEditRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
