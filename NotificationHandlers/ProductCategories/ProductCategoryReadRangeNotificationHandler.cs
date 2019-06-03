namespace crgolden.Api.ProductCategories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryReadRangeNotificationHandler : ReadRangeNotificationHandler<ProductCategoryReadRangeNotification, ProductCategoryModel>
    {
        public ProductCategoryReadRangeNotificationHandler(ILogger<ProductCategoryReadRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
