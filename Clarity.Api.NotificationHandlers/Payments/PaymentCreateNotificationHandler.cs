namespace Clarity.Api.Payments
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class PaymentCreateNotificationHandler : CreateNotificationHandler<PaymentCreateNotification, PaymentModel>
    {
        public PaymentCreateNotificationHandler(ILogger<PaymentCreateNotificationHandler> logger) : base(logger)
        {
        }
    }
}
