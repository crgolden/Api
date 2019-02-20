namespace Clarity.Api.Payments
{
    using System.Collections.Generic;
    using Core;

    public class PaymentCreateRangeRequest : CreateRangeRequest<IEnumerable<Payment>, Payment>
    {
        public PaymentCreateRangeRequest(IEnumerable<Payment> payments) : base(payments)
        {
        }
    }
}
