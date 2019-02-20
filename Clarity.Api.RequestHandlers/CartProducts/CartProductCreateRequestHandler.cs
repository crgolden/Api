namespace Clarity.Api.CartProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartProductCreateRequestHandler : CreateRequestHandler<CartProductCreateRequest, CartProduct>
    {
        public CartProductCreateRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<CartProduct> Handle(CartProductCreateRequest request, CancellationToken cancellationToken)
        {
            var cart = await Context
                .FindAsync<Cart>(new object[] { request.Entity.CartId }, cancellationToken)
                .ConfigureAwait(false);
            if (cart == null) return null;

            cart.Total += request.Entity.ExtendedPrice;

            return await base.Handle(request, cancellationToken);
        }
    }
}
