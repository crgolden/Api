namespace crgolden.Api.Categories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CategoryCreateNotificationHandler : CreateNotificationHandler<CategoryCreateNotification, CategoryModel>
    {
        public CategoryCreateNotificationHandler(ILogger<CategoryCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
