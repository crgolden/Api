namespace Clarity.Api.Categories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CategoryEditRangeNotificationHandler : EditRangeNotificationHandler<CategoryEditRangeNotification, CategoryModel>
    {
        public CategoryEditRangeNotificationHandler(ILogger<CategoryEditRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
