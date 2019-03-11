namespace Clarity.Api.Files
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class FileEditNotificationHandler : EditNotificationHandler<FileEditNotification, Api.FileModel>
    {
        public FileEditNotificationHandler(ILogger<FileEditNotificationHandler> logger) : base(logger)
        {
        }
    }
}
