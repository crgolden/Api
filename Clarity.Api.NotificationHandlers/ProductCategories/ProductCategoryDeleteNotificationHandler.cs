namespace Clarity.Api.ProductCategories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryDeleteNotificationHandler : DeleteNotificationHandler<ProductCategoryDeleteNotification>
    {
        public ProductCategoryDeleteNotificationHandler(ILogger<ProductCategoryDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
