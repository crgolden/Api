namespace crgolden.Api.Categories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CategoryUpdateNotificationHandler : UpdateNotificationHandler<CategoryUpdateNotification, CategoryModel>
    {
        public CategoryUpdateNotificationHandler(ILogger<CategoryUpdateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
