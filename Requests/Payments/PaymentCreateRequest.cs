namespace Clarity.Api.Payments
{
    using System;
    using Abstractions;

    public class PaymentCreateRequest : CreateRequest<Payment, PaymentModel>
    {
        public Guid? UserId { get; set; }

        public string Email { get; set; }

        public PaymentCreateRequest(PaymentModel payment) : base(payment)
        {
        }
    }
}
