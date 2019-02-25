namespace Clarity.Api.Files
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class FileEditNotificationHandler : EditNotificationHandler<FileEditNotification, FileModel>
    {
        public FileEditNotificationHandler(ILogger<FileEditNotificationHandler> logger) : base(logger)
        {
        }
    }
}
