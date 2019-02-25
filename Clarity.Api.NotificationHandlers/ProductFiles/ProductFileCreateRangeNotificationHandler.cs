namespace Clarity.Api.ProductFiles
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductFileCreateRangeNotificationHandler : CreateRangeNotificationHandler<ProductFileCreateRangeNotification, ProductFileModel>
    {
        public ProductFileCreateRangeNotificationHandler(ILogger<ProductFileCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
