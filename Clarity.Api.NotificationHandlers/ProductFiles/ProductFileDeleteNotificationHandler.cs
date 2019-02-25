namespace Clarity.Api.ProductFiles
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductFileDeleteNotificationHandler : DeleteNotificationHandler<ProductFileDeleteNotification>
    {
        public ProductFileDeleteNotificationHandler(ILogger<ProductFileDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
