namespace Clarity.Api.ProductCategories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryCreateNotificationHandler : CreateNotificationHandler<ProductCategoryCreateNotification, ProductCategoryModel>
    {
        public ProductCategoryCreateNotificationHandler(ILogger<ProductCategoryCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
