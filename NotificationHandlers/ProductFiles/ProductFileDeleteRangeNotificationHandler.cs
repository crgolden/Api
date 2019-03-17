namespace Clarity.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductFileDeleteRangeNotificationHandler : DeleteRangeNotificationHandler<ProductFileDeleteRangeNotification>
    {
        public ProductFileDeleteRangeNotificationHandler(ILogger<ProductFileDeleteRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
