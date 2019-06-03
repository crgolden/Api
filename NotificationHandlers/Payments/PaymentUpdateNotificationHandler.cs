namespace crgolden.Api.Payments
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class PaymentUpdateNotificationHandler : UpdateNotificationHandler<PaymentUpdateNotification, PaymentModel>
    {
        public PaymentUpdateNotificationHandler(ILogger<PaymentUpdateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
