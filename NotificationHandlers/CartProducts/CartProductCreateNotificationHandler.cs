namespace crgolden.Api.CartProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartProductCreateNotificationHandler : CreateNotificationHandler<CartProductCreateNotification, CartProductModel>
    {
        public CartProductCreateNotificationHandler(ILogger<CartProductCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
