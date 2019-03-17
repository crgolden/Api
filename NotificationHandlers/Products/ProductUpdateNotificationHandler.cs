namespace Clarity.Api.Products
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductUpdateNotificationHandler : UpdateNotificationHandler<ProductUpdateNotification, ProductModel>
    {
        public ProductUpdateNotificationHandler(ILogger<ProductUpdateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
