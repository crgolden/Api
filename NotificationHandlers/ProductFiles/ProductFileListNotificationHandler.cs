namespace Clarity.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductFileListNotificationHandler : ListNotificationHandler<ProductFileListNotification>
    {
        public ProductFileListNotificationHandler(ILogger<ProductFileListNotificationHandler> logger) : base(logger)
        {
        }
    }
}
