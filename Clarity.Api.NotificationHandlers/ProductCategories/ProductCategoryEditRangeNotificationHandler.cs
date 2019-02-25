namespace Clarity.Api.ProductCategories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryEditRangeNotificationHandler : EditRangeNotificationHandler<ProductCategoryEditRangeNotification, ProductCategoryModel>
    {
        public ProductCategoryEditRangeNotificationHandler(ILogger<ProductCategoryEditRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
