namespace Clarity.Api.Payments
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class PaymentCreateRangeRequestHandler
        : CreateRangeRequestHandler<PaymentCreateRangeRequest, IEnumerable<Payment>, Payment>
    {
        public PaymentCreateRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Payment>> Handle(PaymentCreateRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
