namespace Clarity.Api.Products
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductDetailsNotificationHandler : DetailsNotificationHandler<ProductDetailsNotification, ProductModel>
    {
        public ProductDetailsNotificationHandler(ILogger<ProductDetailsNotificationHandler> logger) : base(logger)
        {
        }
    }
}
