namespace Clarity.Api.Categories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CategoryDetailsNotificationHandler : DetailsNotificationHandler<CategoryDetailsNotification, CategoryModel>
    {
        public CategoryDetailsNotificationHandler(ILogger<CategoryDetailsNotificationHandler> logger) : base(logger)
        {
        }
    }
}
