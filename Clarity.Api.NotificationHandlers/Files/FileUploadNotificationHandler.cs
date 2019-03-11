namespace Clarity.Api.Files
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class FileUploadNotificationHandler : UploadNotificationHandler<FileUploadNotification, Api.FileModel>
    {
        public FileUploadNotificationHandler(ILogger<FileUploadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
