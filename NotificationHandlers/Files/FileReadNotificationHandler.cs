namespace crgolden.Api.Files
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class FileReadNotificationHandler : ReadNotificationHandler<FileReadNotification, FileModel>
    {
        public FileReadNotificationHandler(ILogger<FileReadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
