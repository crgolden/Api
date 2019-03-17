namespace Clarity.Api.Payments
{
    using Abstractions;

    public class PaymentUpdateRequest : UpdateRequest<Payment, PaymentModel>
    {
        public PaymentUpdateRequest(PaymentModel payment) : base(payment)
        {
        }
    }
}
