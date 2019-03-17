namespace Clarity.Api.ProductCategories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductCategoryUpdateRangeNotificationHandler : UpdateRangeNotificationHandler<ProductCategoryUpdateRangeNotification, ProductCategoryModel>
    {
        public ProductCategoryUpdateRangeNotificationHandler(ILogger<ProductCategoryUpdateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
