namespace Clarity.Api.ProductFiles
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductFileEditNotificationHandler : EditNotificationHandler<ProductFileEditNotification, ProductFileModel>
    {
        public ProductFileEditNotificationHandler(ILogger<ProductFileEditNotificationHandler> logger) : base(logger)
        {
        }
    }
}
