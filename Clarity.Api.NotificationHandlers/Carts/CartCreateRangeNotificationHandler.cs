namespace Clarity.Api.Carts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartCreateRangeNotificationHandler : CreateRangeNotificationHandler<CartCreateRangeNotification, CartModel>
    {
        public CartCreateRangeNotificationHandler(ILogger<CartCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
