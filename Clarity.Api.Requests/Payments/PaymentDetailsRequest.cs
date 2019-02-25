namespace Clarity.Api.Payments
{
    using System;
    using Core;

    public class PaymentDetailsRequest : DetailsRequest<Payment, PaymentModel>
    {
        public readonly Guid PaymentId;

        public readonly Guid? UserId;

        public PaymentDetailsRequest(Guid paymentId, Guid? userId = null) : base(new object[] { paymentId })
        {
            PaymentId = paymentId;
            UserId = userId;
        }
    }
}
