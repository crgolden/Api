namespace crgolden.Api.Payments
{
    using System;
    using Abstractions;

    public class PaymentDeleteRequest : DeleteRequest
    {
        public readonly Guid PaymentId;

        public PaymentDeleteRequest(Guid paymentId) : base(new object[] { paymentId })
        {
            PaymentId = paymentId;
        }
    }
}
