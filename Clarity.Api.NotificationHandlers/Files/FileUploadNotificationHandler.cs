namespace Clarity.Api.Files
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class FileUploadNotificationHandler : INotificationHandler<FileUploadNotification>
    {
        private readonly ILogger<FileUploadNotificationHandler> _logger;

        public FileUploadNotificationHandler(ILogger<FileUploadNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(FileUploadNotification notification, CancellationToken token)
        {
            switch (notification.EventId)
            {
                case EventIds.UploadStart:
                    _logger.LogInformation(
                        eventId: new EventId((int)EventIds.UploadStart, $"{EventIds.UploadStart}"),
                        message: "Uploading files {Files} at {Time}",
                        args: new object[] { notification.Files, DateTime.UtcNow });
                    break;
                case EventIds.UploadEnd:
                    _logger.LogInformation(
                        eventId: new EventId((int)EventIds.UploadEnd, $"{EventIds.UploadEnd}"),
                        message: "Uploaded models {Models} at {Time}",
                        args: new object[] { notification.Models, DateTime.UtcNow });
                    break;
                case EventIds.UploadError:
                    _logger.LogError(
                        eventId: new EventId((int)EventIds.UploadError, $"{EventIds.UploadError}"),
                        exception: notification.Exception,
                        message: "Error uploading files {Files} at {Time}",
                        args: new object[] { notification.Files, DateTime.UtcNow });
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
