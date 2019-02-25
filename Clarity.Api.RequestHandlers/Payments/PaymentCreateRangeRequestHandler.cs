namespace Clarity.Api.Payments
{
    using System.Collections.Generic;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class PaymentCreateRangeRequestHandler : CreateRangeRequestHandler<PaymentCreateRangeRequest, IEnumerable<PaymentModel>, Payment, PaymentModel>
    {
        public PaymentCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
