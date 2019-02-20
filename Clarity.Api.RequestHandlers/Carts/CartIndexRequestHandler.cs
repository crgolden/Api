namespace Clarity.Api.Carts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;

    public class CartIndexRequestHandler : IndexRequestHandler<CartIndexRequest, Cart>
    {
        public CartIndexRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<DataSourceResult> Handle(CartIndexRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
