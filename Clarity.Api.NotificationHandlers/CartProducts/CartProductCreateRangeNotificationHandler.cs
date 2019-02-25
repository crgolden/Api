namespace Clarity.Api.CartProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartProductCreateRangeNotificationHandler : CreateRangeNotificationHandler<CartProductCreateRangeNotification, CartProductModel>
    {
        public CartProductCreateRangeNotificationHandler(ILogger<CartProductCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
