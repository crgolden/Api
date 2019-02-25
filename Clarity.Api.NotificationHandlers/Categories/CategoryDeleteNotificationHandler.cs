namespace Clarity.Api.Categories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CategoryDeleteNotificationHandler : DeleteNotificationHandler<CategoryDeleteNotification>
    {
        public CategoryDeleteNotificationHandler(ILogger<CategoryDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
