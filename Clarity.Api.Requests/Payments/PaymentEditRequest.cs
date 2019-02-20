namespace Clarity.Api.Payments
{
    using Core;

    public class PaymentEditRequest : EditRequest<Payment>
    {
        public PaymentEditRequest(Payment payment) : base(payment)
        {
        }
    }
}
