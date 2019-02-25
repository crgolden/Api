namespace Clarity.Api.Files
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class FileCreateRangeNotificationHandler : CreateRangeNotificationHandler<FileCreateRangeNotification, FileModel>
    {
        public FileCreateRangeNotificationHandler(ILogger<FileCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
