namespace Clarity.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductFileUpdateRangeNotificationHandler : UpdateRangeNotificationHandler<ProductFileUpdateRangeNotification, ProductFileModel>
    {
        public ProductFileUpdateRangeNotificationHandler(ILogger<ProductFileUpdateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
