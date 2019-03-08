namespace Clarity.Api.Payments
{
    using System;
    using Core;

    public class PaymentCreateRequest : CreateRequest<Payment, PaymentModel>
    {
        public Guid? UserId { get; set; }

        public string Email { get; set; }

        public PaymentCreateRequest(PaymentModel payment) : base(payment)
        {
        }
    }
}
