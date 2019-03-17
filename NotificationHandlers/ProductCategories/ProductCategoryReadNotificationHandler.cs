namespace Clarity.Api.ProductCategories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryReadNotificationHandler : ReadNotificationHandler<ProductCategoryReadNotification, ProductCategoryModel>
    {
        public ProductCategoryReadNotificationHandler(ILogger<ProductCategoryReadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
