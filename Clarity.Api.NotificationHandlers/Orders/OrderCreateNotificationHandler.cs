namespace Clarity.Api.Orders
{
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
            ILogger<OrderCreateNotificationHandler> logger,
            IOptions<ServiceBusOptions> serviceBusOptions) : base(logger)
        {
            _emailQueueClient = new QueueClient(
                connectionStringBuilder: new ServiceBusConnectionStringBuilder(
                    endpoint: serviceBusOptions.Value.Endpoint,
                    entityPath: serviceBusOptions.Value.EmailQueueName,
                    sharedAccessKeyName: serviceBusOptions.Value.SharedAccessKeyName,
                    sharedAccessKey: serviceBusOptions.Value.PrimaryKey,
                    transportType: TransportType.Amqp));
        }

        public override async Task Handle(OrderCreateNotification notification, CancellationToken cancellationToken)
        {
            var body = Encoding.UTF8.GetBytes("");
            var message = new Message(body);
            message.UserProperties.Add("email", notification.UserEmail);
            message.UserProperties.Add("subject", string.Format(Subject, notification.Model.Number));
            await _emailQueueClient.SendAsync(message).ConfigureAwait(false);
            await _emailQueueClient.CloseAsync().ConfigureAwait(false);
            await base.Handle(notification, cancellationToken).ConfigureAwait(false);
        }
    }
}
