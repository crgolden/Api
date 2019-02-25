namespace Clarity.Api.Payments
{
    using Core;

    public class PaymentEditRequest : EditRequest<Payment, PaymentModel>
    {
        public PaymentEditRequest(PaymentModel payment) : base(payment)
        {
        }
    }
}
