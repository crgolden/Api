namespace crgolden.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductFileCreateRangeNotificationHandler : CreateRangeNotificationHandler<ProductFileCreateRangeNotification, ProductFileModel>
    {
        public ProductFileCreateRangeNotificationHandler(ILogger<ProductFileCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
