namespace crgolden.Api.ProductCategories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryUpdateNotificationHandler : UpdateNotificationHandler<ProductCategoryUpdateNotification, ProductCategoryModel>
    {
        public ProductCategoryUpdateNotificationHandler(ILogger<ProductCategoryUpdateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
