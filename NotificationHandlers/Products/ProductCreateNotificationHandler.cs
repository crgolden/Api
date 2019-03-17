namespace Clarity.Api.Products
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductCreateNotificationHandler : CreateNotificationHandler<ProductCreateNotification, ProductModel>
    {
        public ProductCreateNotificationHandler(ILogger<ProductCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
