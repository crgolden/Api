namespace crgolden.Api.ProductCategories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryDeleteRangeNotificationHandler : DeleteRangeNotificationHandler<ProductCategoryDeleteRangeNotification>
    {
        public ProductCategoryDeleteRangeNotificationHandler(ILogger<ProductCategoryDeleteRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
