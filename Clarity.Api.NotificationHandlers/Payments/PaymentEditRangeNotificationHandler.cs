namespace Clarity.Api.Payments
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class PaymentEditRangeNotificationHandler : EditRangeNotificationHandler<PaymentEditRangeNotification, PaymentModel>
    {
        public PaymentEditRangeNotificationHandler(ILogger<PaymentEditRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
