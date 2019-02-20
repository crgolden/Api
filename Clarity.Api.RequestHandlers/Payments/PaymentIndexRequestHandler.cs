namespace Clarity.Api.Payments
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;

    public class PaymentIndexRequestHandler : IndexRequestHandler<PaymentIndexRequest, Payment>
    {
        public PaymentIndexRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<DataSourceResult> Handle(PaymentIndexRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
