namespace Clarity.Api.Products
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductCreateNotificationHandler : CreateNotificationHandler<ProductCreateNotification, ProductModel>
    {
        public ProductCreateNotificationHandler(ILogger<ProductCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
