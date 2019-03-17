namespace Clarity.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductFileUpdateNotificationHandler : UpdateNotificationHandler<ProductFileUpdateNotification, ProductFileModel>
    {
        public ProductFileUpdateNotificationHandler(ILogger<ProductFileUpdateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
