namespace crgolden.Api.Products
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductListNotificationHandler : ListNotificationHandler<ProductListNotification>
    {
        public ProductListNotificationHandler(ILogger<ProductListNotificationHandler> logger) : base(logger)
        {
        }
    }
}
