namespace Clarity.Api.Payments
{
    using System;
    using Core;

    public class PaymentDeleteRequest : DeleteRequest
    {
        public readonly Guid PaymentId;

        public PaymentDeleteRequest(Guid paymentId) : base(new object[] { paymentId })
        {
            PaymentId = paymentId;
        }
    }
}
