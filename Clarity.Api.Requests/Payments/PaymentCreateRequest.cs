namespace Clarity.Api.Payments
{
    using Core;

    public class PaymentCreateRequest : CreateRequest<Payment>
    {
        public PaymentCreateRequest(Payment payment) : base(payment)
        {
        }
    }
}
