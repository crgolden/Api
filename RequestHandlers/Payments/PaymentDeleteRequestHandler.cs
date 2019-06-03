namespace crgolden.Api.Payments
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class PaymentDeleteRequestHandler : DeleteRequestHandler<PaymentDeleteRequest, Payment>
    {
        public PaymentDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
