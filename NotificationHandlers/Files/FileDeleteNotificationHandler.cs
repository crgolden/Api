namespace Clarity.Api.Files
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
