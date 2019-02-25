namespace Clarity.Api.ProductFiles
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductFileDetailsNotificationHandler : DetailsNotificationHandler<ProductFileDetailsNotification, ProductFileModel>
    {
        public ProductFileDetailsNotificationHandler(ILogger<ProductFileDetailsNotificationHandler> logger) : base(logger)
        {
        }
    }
}
