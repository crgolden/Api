namespace Clarity.Api.CartProducts
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CartProductIndexNotificationHandler : IndexNotificationHandler<CartProductIndexNotification>
    {
        public CartProductIndexNotificationHandler(ILogger<CartProductIndexNotificationHandler> logger) : base(logger)
        {
        }
    }
}
