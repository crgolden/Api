namespace Clarity.Api.Categories
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class CategoryReadNotificationHandler : ReadNotificationHandler<CategoryReadNotification, CategoryModel>
    {
        public CategoryReadNotificationHandler(ILogger<CategoryReadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
