namespace Clarity.Api.Payments
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class PaymentEditNotificationHandler : EditNotificationHandler<PaymentEditNotification, PaymentModel>
    {
        public PaymentEditNotificationHandler(ILogger<PaymentEditNotificationHandler> logger) : base(logger)
        {
        }
    }
}
