namespace Clarity.Api.ProductCategories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryEditNotificationHandler : EditNotificationHandler<ProductCategoryEditNotification, ProductCategoryModel>
    {
        public ProductCategoryEditNotificationHandler(ILogger<ProductCategoryEditNotificationHandler> logger) : base(logger)
        {
        }
    }
}
