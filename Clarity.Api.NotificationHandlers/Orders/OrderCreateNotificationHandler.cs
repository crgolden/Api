﻿namespace Clarity.Api.Orders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.Azure.ServiceBus;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class OrderCreateNotificationHandler : CreateNotificationHandler<OrderCreateNotification, OrderModel>
    {
        private readonly IQueueClient _emailQueueClient;
        private const string Subject = "Order Details (#{0})";

        public OrderCreateNotificationHandler(
            IEnumerable<IQueueClient> queueClients,
            IOptions<ServiceBusOptions> serviceBusOptions,
            ILogger<OrderCreateNotificationHandler> logger) : base(logger)
        {
            _emailQueueClient = queueClients.Single(x => x.QueueName == serviceBusOptions.Value.EmailQueueName);
        }

        public override async Task Handle(OrderCreateNotification notification, CancellationToken cancellationToken)
        {
            var body = Encoding.UTF8.GetBytes("");
            var message = new Message(body);
            message.UserProperties.Add("email", notification.UserEmail);
            message.UserProperties.Add("subject", string.Format(Subject, notification.Model.Number));
            await _emailQueueClient.SendAsync(message).ConfigureAwait(false);
            await base.Handle(notification, cancellationToken).ConfigureAwait(false);
        }
    }
}
