namespace Clarity.Api.Payments
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.Extensions.Logging;

    public class PaymentDeleteNotificationHandler : DeleteNotificationHandler<PaymentDeleteNotification>
    {
        public PaymentDeleteNotificationHandler(ILogger<PaymentDeleteNotificationHandler> logger) : base(logger)
        {
        }

        public override Task Handle(PaymentDeleteNotification notification, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}
