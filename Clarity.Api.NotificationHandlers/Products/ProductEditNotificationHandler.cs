namespace Clarity.Api.Products
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductEditNotificationHandler : EditNotificationHandler<ProductEditNotification, ProductModel>
    {
        public ProductEditNotificationHandler(ILogger<ProductEditNotificationHandler> logger) : base(logger)
        {
        }
    }
}
