namespace crgolden.Api.Payments
{
    using Abstractions;

    public class PaymentCreateRequest : CreateRequest<Payment, PaymentModel>
    {
        public string Email { get; set; }

        public PaymentCreateRequest(PaymentModel payment) : base(payment)
        {
        }
    }
}
