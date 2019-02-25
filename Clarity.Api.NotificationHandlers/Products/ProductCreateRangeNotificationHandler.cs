namespace Clarity.Api.Products
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductCreateRangeNotificationHandler : CreateRangeNotificationHandler<ProductCreateRangeNotification, ProductModel>
    {
        public ProductCreateRangeNotificationHandler(ILogger<ProductCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
