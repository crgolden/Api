namespace Clarity.Api.Products
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductIndexNotificationHandler : IndexNotificationHandler<ProductIndexNotification>
    {
        public ProductIndexNotificationHandler(ILogger<ProductIndexNotificationHandler> logger) : base(logger)
        {
        }
    }
}
