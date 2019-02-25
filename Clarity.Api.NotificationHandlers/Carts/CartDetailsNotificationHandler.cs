namespace Clarity.Api.Carts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartDetailsNotificationHandler : DetailsNotificationHandler<CartDetailsNotification, CartModel>
    {
        public CartDetailsNotificationHandler(ILogger<CartDetailsNotificationHandler> logger) : base(logger)
        {
        }
    }
}
