namespace Clarity.Api.Categories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CategoryEditNotificationHandler : EditNotificationHandler<CategoryEditNotification, CategoryModel>
    {
        public CategoryEditNotificationHandler(ILogger<CategoryEditNotificationHandler> logger) : base(logger)
        {
        }
    }
}
