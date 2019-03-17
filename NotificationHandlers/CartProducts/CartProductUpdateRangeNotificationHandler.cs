namespace Clarity.Api.CartProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartProductUpdateRangeNotificationHandler : UpdateRangeNotificationHandler<CartProductUpdateRangeNotification, CartProductModel>
    {
        public CartProductUpdateRangeNotificationHandler(ILogger<CartProductUpdateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
