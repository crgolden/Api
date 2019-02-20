namespace Clarity.Api.Payments
{
    using System.Collections.Generic;
    using Core;

    public class PaymentEditRangeRequest : EditRangeRequest<Payment>
    {
        public PaymentEditRangeRequest(IEnumerable<Payment> payments) : base(payments)
        {
        }
    }
}
