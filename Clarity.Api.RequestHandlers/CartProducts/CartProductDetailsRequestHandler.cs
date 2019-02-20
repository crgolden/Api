namespace Clarity.Api.CartProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartProductDetailsRequestHandler : DetailsRequestHandler<CartProductDetailsRequest, CartProduct>
    {
        public CartProductDetailsRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<CartProduct> Handle(CartProductDetailsRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
