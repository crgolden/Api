namespace Clarity.Api.Carts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartEditRangeNotificationHandler : EditRangeNotificationHandler<CartEditRangeNotification, CartModel>
    {
        public CartEditRangeNotificationHandler(ILogger<CartEditRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
