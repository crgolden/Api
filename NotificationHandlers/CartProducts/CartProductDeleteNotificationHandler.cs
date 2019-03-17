namespace Clarity.Api.CartProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartProductDeleteNotificationHandler : DeleteNotificationHandler<CartProductDeleteNotification>
    {
        public CartProductDeleteNotificationHandler(ILogger<CartProductDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
