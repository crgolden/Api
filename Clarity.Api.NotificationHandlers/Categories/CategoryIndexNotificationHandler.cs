namespace Clarity.Api.Categories
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class CategoryIndexNotificationHandler : IndexNotificationHandler<CategoryIndexNotification>
    {
        public CategoryIndexNotificationHandler(ILogger<CategoryIndexNotificationHandler> logger) : base(logger)
        {
        }
    }
}
