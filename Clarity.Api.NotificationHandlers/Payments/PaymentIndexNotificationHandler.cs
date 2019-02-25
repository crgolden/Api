namespace Clarity.Api.Payments
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class PaymentIndexNotificationHandler : IndexNotificationHandler<PaymentIndexNotification>
    {
        public PaymentIndexNotificationHandler(ILogger<PaymentIndexNotificationHandler> logger) : base(logger)
        {
        }
    }
}
