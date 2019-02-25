namespace Clarity.Api.Payments
{
    using Core;

    public class PaymentCreateRequest : CreateRequest<Payment, PaymentModel>
    {
        public string Email { get; set; }

        public PaymentCreateRequest(PaymentModel payment) : base(payment)
        {
        }
    }
}
