namespace Clarity.Api.ProductCategories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryIndexNotificationHandler : IndexNotificationHandler<ProductCategoryIndexNotification>
    {
        public ProductCategoryIndexNotificationHandler(ILogger<ProductCategoryIndexNotificationHandler> logger) : base(logger)
        {
        }
    }
}
