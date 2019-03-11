namespace Clarity.Api.Files
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class FileEditRangeNotificationHandler : EditRangeNotificationHandler<FileEditRangeNotification, Api.FileModel>
    {
        public FileEditRangeNotificationHandler(ILogger<FileEditRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
