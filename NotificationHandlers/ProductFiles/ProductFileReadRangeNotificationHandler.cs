namespace Clarity.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductFileReadRangeNotificationHandler : ReadRangeNotificationHandler<ProductFileReadRangeNotification, ProductFileModel>
    {
        public ProductFileReadRangeNotificationHandler(ILogger<ProductFileReadRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
