namespace crgolden.Api.ProductCategories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryDeleteNotificationHandler : DeleteNotificationHandler<ProductCategoryDeleteNotification>
    {
        public ProductCategoryDeleteNotificationHandler(ILogger<ProductCategoryDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
