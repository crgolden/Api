namespace Clarity.Api.ProductFiles
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductFileCreateNotificationHandler : CreateNotificationHandler<ProductFileCreateNotification, ProductFileModel>
    {
        public ProductFileCreateNotificationHandler(ILogger<ProductFileCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
