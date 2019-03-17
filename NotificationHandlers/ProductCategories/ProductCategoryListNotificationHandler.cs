namespace Clarity.Api.ProductCategories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryListNotificationHandler : ListNotificationHandler<ProductCategoryListNotification>
    {
        public ProductCategoryListNotificationHandler(ILogger<ProductCategoryListNotificationHandler> logger) : base(logger)
        {
        }
    }
}
