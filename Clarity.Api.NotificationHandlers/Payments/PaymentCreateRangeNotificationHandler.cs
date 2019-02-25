namespace Clarity.Api.Payments
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class PaymentCreateRangeNotificationHandler : CreateRangeNotificationHandler<PaymentCreateRangeNotification, PaymentModel>
    {
        public PaymentCreateRangeNotificationHandler(ILogger<PaymentCreateRangeNotificationHandler> logger) : base(logger)
        {
        }
    }
}
