namespace Clarity.Api.Payments
{
    using System.Collections.Generic;
    using Core;

    public class PaymentCreateRangeRequest : CreateRangeRequest<IEnumerable<PaymentModel>, Payment, PaymentModel>
    {
        public PaymentCreateRangeRequest(IEnumerable<PaymentModel> payments) : base(payments)
        {
        }
    }
}
