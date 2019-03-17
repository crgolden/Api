namespace Clarity.Api.CartProducts
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CartProductDeleteRangeNotificationHandler : DeleteRangeNotificationHandler<CartProductDeleteRangeNotification>
    {
        public CartProductDeleteRangeNotificationHandler(ILogger<CartProductDeleteRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
