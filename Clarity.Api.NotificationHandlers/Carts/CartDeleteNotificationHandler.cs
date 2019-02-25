namespace Clarity.Api.Carts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartDeleteNotificationHandler : DeleteNotificationHandler<CartDeleteNotification>
    {
        public CartDeleteNotificationHandler(ILogger<CartDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
