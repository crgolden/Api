namespace Clarity.Api.ProductFiles
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductFileEditRangeNotificationHandler : EditRangeNotificationHandler<ProductFileEditRangeNotification, ProductFileModel>
    {
        public ProductFileEditRangeNotificationHandler(ILogger<ProductFileEditRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
