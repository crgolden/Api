namespace Clarity.Api.CartProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartProductDeleteNotificationHandler : DeleteNotificationHandler<CartProductDeleteNotification>
    {
        public CartProductDeleteNotificationHandler(ILogger<CartProductDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
