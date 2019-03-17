namespace Clarity.Api.Payments
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class PaymentListNotificationHandler : ListNotificationHandler<PaymentListNotification>
    {
        public PaymentListNotificationHandler(ILogger<PaymentListNotificationHandler> logger) : base(logger)
        {
        }
    }
}
