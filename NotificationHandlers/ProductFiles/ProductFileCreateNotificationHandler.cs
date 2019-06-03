namespace crgolden.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductFileCreateNotificationHandler : CreateNotificationHandler<ProductFileCreateNotification, ProductFileModel>
    {
        public ProductFileCreateNotificationHandler(ILogger<ProductFileCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
