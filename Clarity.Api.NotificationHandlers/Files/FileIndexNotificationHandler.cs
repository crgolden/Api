namespace Clarity.Api.Files
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class FileIndexNotificationHandler : IndexNotificationHandler<FileIndexNotification>
    {
        public FileIndexNotificationHandler(ILogger<FileIndexNotificationHandler> logger) : base(logger)
        {
        }
    }
}
