namespace crgolden.Api.Files
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class FileCreateNotificationHandler : CreateNotificationHandler<FileCreateNotification, FileModel>
    {
        public FileCreateNotificationHandler(ILogger<FileCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
