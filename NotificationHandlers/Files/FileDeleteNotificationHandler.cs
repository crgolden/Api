namespace crgolden.Api.Files
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class FileDeleteNotificationHandler : DeleteNotificationHandler<FileDeleteNotification>
    {
        public FileDeleteNotificationHandler(ILogger<FileDeleteNotificationHandler> logger) : base(logger)
        {
        }
    }
}
