namespace Clarity.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductFileReadNotificationHandler : ReadNotificationHandler<ProductFileReadNotification, ProductFileModel>
    {
        public ProductFileReadNotificationHandler(ILogger<ProductFileReadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
