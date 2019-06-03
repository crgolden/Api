namespace crgolden.Api.Categories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CategoryDeleteNotificationHandler : DeleteNotificationHandler<CategoryDeleteNotification>
    {
        public CategoryDeleteNotificationHandler(ILogger<CategoryDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
