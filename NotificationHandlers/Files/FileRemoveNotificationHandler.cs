namespace crgolden.Api.Files
{
    using System;
    using Core.Files;
    using Microsoft.Extensions.Logging;

    public class FileRemoveNotificationHandler : FileRemoveNotificationHandler<FileRemoveNotification, Guid>
    {
        public FileRemoveNotificationHandler(ILogger<FileRemoveNotificationHandler> logger) : base(logger)
        {
        }
    }
}
