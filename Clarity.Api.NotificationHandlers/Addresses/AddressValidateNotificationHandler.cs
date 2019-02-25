namespace Clarity.Api.Addresses
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class AddressValidateNotificationHandler : INotificationHandler<AddressValidateNotification>
    {
        private readonly ILogger<AddressValidateNotificationHandler> _logger;

        public AddressValidateNotificationHandler(ILogger<AddressValidateNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AddressValidateNotification notification, CancellationToken cancellationToken)
        {
            switch (notification.EventId)
            {
                case EventIds.ValidateStart:
                    _logger.LogInformation(
                        eventId: new EventId((int)EventIds.ValidateStart, $"{EventIds.ValidateStart}"),
                        message: "Validating model {Model} at {Time}",
                        args: new object[] { notification.Model, DateTime.UtcNow });
                    break;
                case EventIds.ValidateEnd:
                    _logger.LogInformation(
                        eventId: new EventId((int)EventIds.ValidateEnd, $"{EventIds.ValidateEnd}"),
                        message: "Validated model {Model} at {Time}",
                        args: new object[] { notification.Model, DateTime.UtcNow });
                    break;
                case EventIds.ValidateError:
                    _logger.LogError(
                        eventId: new EventId((int)EventIds.ValidateError, $"{EventIds.ValidateError}"),
                        exception: notification.Exception,
                        message: "Error validating model {Model} at {Time}",
                        args: new object[] { notification.Model, DateTime.UtcNow });
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
