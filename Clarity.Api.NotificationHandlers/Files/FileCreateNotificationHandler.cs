namespace Clarity.Api.Files
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class FileCreateNotificationHandler : CreateNotificationHandler<FileCreateNotification, Api.FileModel>
    {
        public FileCreateNotificationHandler(ILogger<FileCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
