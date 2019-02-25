namespace Clarity.Api.Payments
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class PaymentDetailsNotificationHandler : DetailsNotificationHandler<PaymentDetailsNotification, PaymentModel>
    {
        public PaymentDetailsNotificationHandler(ILogger<PaymentDetailsNotificationHandler> logger) : base(logger)
        {
        }
    }
}
