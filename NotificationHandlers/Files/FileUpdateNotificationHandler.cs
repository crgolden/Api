namespace crgolden.Api.Files
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class FileUpdateNotificationHandler : UpdateNotificationHandler<FileUpdateNotification, FileModel>
    {
        public FileUpdateNotificationHandler(ILogger<FileUpdateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
