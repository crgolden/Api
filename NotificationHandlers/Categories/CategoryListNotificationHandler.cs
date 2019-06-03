namespace crgolden.Api.Categories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CategoryListNotificationHandler : ListNotificationHandler<CategoryListNotification>
    {
        public CategoryListNotificationHandler(ILogger<CategoryListNotificationHandler> logger) : base(logger)
        {
        }
    }
}
