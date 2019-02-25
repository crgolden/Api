namespace Clarity.Api.ProductCategories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryDetailsNotificationHandler : DetailsNotificationHandler<ProductCategoryDetailsNotification, ProductCategoryModel>
    {
        public ProductCategoryDetailsNotificationHandler(ILogger<ProductCategoryDetailsNotificationHandler> logger) : base(logger)
        {
        }
    }
}
