namespace Clarity.Api.Carts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartIndexNotificationHandler : IndexNotificationHandler<CartIndexNotification>
    {
        public CartIndexNotificationHandler(ILogger<CartIndexNotificationHandler> logger) : base(logger)
        {
        }
    }
}
