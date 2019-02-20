namespace Clarity.Api.CartProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;

    public class CartProductIndexRequestHandler : IndexRequestHandler<CartProductIndexRequest, CartProduct>
    {
        public CartProductIndexRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<DataSourceResult> Handle(CartProductIndexRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
