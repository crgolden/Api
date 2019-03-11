namespace Clarity.Api.Files
{
    using System;
    using Core;
    using Microsoft.Extensions.Logging;

    public class FileRemoveNotificationHandler : RemoveNotificationHandler<FileRemoveNotification, Guid>
    {
        public FileRemoveNotificationHandler(ILogger<FileRemoveNotificationHandler> logger) : base(logger)
        {
        }
    }
}
