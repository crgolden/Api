namespace crgolden.Api.Payments
{
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class PaymentCreateNotificationHandler : CreateNotificationHandler<PaymentCreateNotification, PaymentModel>
    {
        public PaymentCreateNotificationHandler(ILogger<PaymentCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
