namespace Clarity.Api.Products
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductReadNotificationHandler : ReadNotificationHandler<ProductReadNotification, ProductModel>
    {
        public ProductReadNotificationHandler(ILogger<ProductReadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
