namespace Clarity.Api.ProductCategories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryCreateRangeNotificationHandler : CreateRangeNotificationHandler<ProductCategoryCreateRangeNotification, ProductCategoryModel>
    {
        public ProductCategoryCreateRangeNotificationHandler(ILogger<ProductCategoryCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
