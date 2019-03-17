namespace Clarity.Api.CartProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartProductListNotificationHandler : ListNotificationHandler<CartProductListNotification>
    {
        public CartProductListNotificationHandler(ILogger<CartProductListNotificationHandler> logger) : base(logger)
        {
        }
    }
}
