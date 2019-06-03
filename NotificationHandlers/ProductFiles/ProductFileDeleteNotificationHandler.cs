namespace crgolden.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductFileDeleteNotificationHandler : DeleteNotificationHandler<ProductFileDeleteNotification>
    {
        public ProductFileDeleteNotificationHandler(ILogger<ProductFileDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
