namespace Clarity.Api.Payments
{
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class PaymentDeleteRequestHandler : DeleteRequestHandler<PaymentDeleteRequest, Payment>
    {
        public PaymentDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
