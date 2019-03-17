namespace Clarity.Api.Payments
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class PaymentReadNotificationHandler : ReadNotificationHandler<PaymentReadNotification, PaymentModel>
    {
        public PaymentReadNotificationHandler(ILogger<PaymentReadNotificationHandler> logger) : base(logger)
        {
        }
    }
}
