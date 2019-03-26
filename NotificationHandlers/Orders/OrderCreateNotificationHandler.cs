namespace Clarity.Api.Orders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Microsoft.Azure.ServiceBus;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Shared;

    public class OrderCreateNotificationHandler : CreateNotificationHandler<OrderCreateNotification, OrderModel>
    {
        private readonly IQueueClient _emailQueueClient;
        private const string Subject = "Order #{0} Read";
        private const string Body = "<a href='{0}/orders/details/{1}'>Order #{2} Details</a>";

        public OrderCreateNotificationHandler(
            IEnumerable<IQueueClient> queueClients,
            IOptions<ServiceBusOptions> serviceBusOptions,
            ILogger<OrderCreateNotificationHandler> logger) : base(logger)
        {
            _emailQueueClient = queueClients.Single(x => x.QueueName == serviceBusOptions.Value.EmailQueueName);
        }

        public override async Task Handle(OrderCreateNotification notification, CancellationToken token)
        {
            if (notification.EventId == EventIds.CreateEnd)
            {
                var body = string.Format(Body, new object[]
                {
                    notification.Origin,
                    notification.Model.Id,
                    notification.Model.Number
                });
                var bytes = Encoding.UTF8.GetBytes(body);
                var message = new Message(bytes);
                message.UserProperties.Add("subject", string.Format(Subject, notification.Model.Number));
                foreach (var email in notification.Emails)
                {
                    message.UserProperties["email"] = email;
                    await _emailQueueClient.SendAsync(message).ConfigureAwait(false);
                }
            }

            await base.Handle(notification, token).ConfigureAwait(false);
        }
    }
}
