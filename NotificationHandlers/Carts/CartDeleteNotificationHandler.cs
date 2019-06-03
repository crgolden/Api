namespace crgolden.Api.Carts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartDeleteNotificationHandler : DeleteNotificationHandler<CartDeleteNotification>
    {
        public CartDeleteNotificationHandler(ILogger<CartDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
