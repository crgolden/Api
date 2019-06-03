namespace crgolden.Api.Payments
{
    using System;
    using Abstractions;

    public class PaymentReadRequest : ReadRequest<Payment, PaymentModel>
    {
        public readonly Guid PaymentId;

        public readonly Guid? UserId;

        public PaymentReadRequest(Guid paymentId, Guid? userId = null) : base(new object[] { paymentId })
        {
            PaymentId = paymentId;
            UserId = userId;
        }
    }
}
