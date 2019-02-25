namespace Clarity.Api.ProductFiles
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductFileIndexNotificationHandler : IndexNotificationHandler<ProductFileIndexNotification>
    {
        public ProductFileIndexNotificationHandler(ILogger<ProductFileIndexNotificationHandler> logger) : base(logger)
        {
        }
    }
}
