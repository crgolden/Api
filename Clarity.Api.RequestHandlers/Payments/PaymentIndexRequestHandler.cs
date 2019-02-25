namespace Clarity.Api.Payments
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class PaymentIndexRequestHandler : IndexRequestHandler<PaymentIndexRequest, Payment, PaymentModel>
    {
        public PaymentIndexRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
