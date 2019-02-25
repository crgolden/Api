namespace Clarity.Api.Categories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CategoryCreateRangeNotificationHandler : CreateRangeNotificationHandler<CategoryCreateRangeNotification, CategoryModel>
    {
        public CategoryCreateRangeNotificationHandler(ILogger<CategoryCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
