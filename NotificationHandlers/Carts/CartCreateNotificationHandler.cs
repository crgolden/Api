namespace Clarity.Api.Carts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartCreateNotificationHandler : CreateNotificationHandler<CartCreateNotification, CartModel>
    {
        public CartCreateNotificationHandler(ILogger<CartCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
