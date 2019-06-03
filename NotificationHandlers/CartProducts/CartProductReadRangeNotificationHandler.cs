namespace crgolden.Api.CartProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartProductReadRangeNotificationHandler : ReadRangeNotificationHandler<CartProductReadRangeNotification, CartProductModel>
    {
        public CartProductReadRangeNotificationHandler(ILogger<CartProductReadRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
