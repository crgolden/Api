namespace Clarity.Api.Payments
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class PaymentEditRangeRequestHandler : EditRangeRequestHandler<PaymentEditRangeRequest, Payment, PaymentModel>
    {
        public PaymentEditRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
