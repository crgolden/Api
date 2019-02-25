namespace Clarity.Api.Carts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartEditNotificationHandler : EditNotificationHandler<CartEditNotification, CartModel>
    {
        public CartEditNotificationHandler(ILogger<CartEditNotificationHandler> logger) : base(logger)
        {
        }
    }
}
