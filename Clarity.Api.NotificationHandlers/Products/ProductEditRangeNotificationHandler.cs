namespace Clarity.Api.Products
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductEditRangeNotificationHandler : EditRangeNotificationHandler<ProductEditRangeNotification, ProductModel>
    {
        public ProductEditRangeNotificationHandler(ILogger<ProductEditRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
