namespace Clarity.Api.Payments
{
    using System.Collections.Generic;
    using Core;

    public class PaymentEditRangeRequest : EditRangeRequest<Payment, PaymentModel>
    {
        public PaymentEditRangeRequest(IEnumerable<PaymentModel> payments) : base(payments)
        {
        }
    }
}
