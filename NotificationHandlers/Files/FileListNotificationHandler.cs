namespace Clarity.Api.Files
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class FileListNotificationHandler : ListNotificationHandler<FileListNotification>
    {
        public FileListNotificationHandler(ILogger<FileListNotificationHandler> logger) : base(logger)
        {
        }
    }
}
