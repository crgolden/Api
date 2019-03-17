namespace Clarity.Api.Files
{
    using Core.Files;
    using Microsoft.Extensions.Logging;

    public class FileUploadNotificationHandler : FileUploadNotificationHandler<FileUploadNotification, FileModel>
    {
        public FileUploadNotificationHandler(ILogger<FileUploadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
