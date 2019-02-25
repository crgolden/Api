namespace Clarity.Api.Files
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class FileEditRangeNotificationHandler : EditRangeNotificationHandler<FileEditRangeNotification, FileModel>
    {
        public FileEditRangeNotificationHandler(ILogger<FileEditRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
