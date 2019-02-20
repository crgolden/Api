namespace Clarity.Api.CartProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CartProductDeleteRequestHandler : DeleteRequestHandler<CartProductDeleteRequest, CartProduct>
    {
        public CartProductDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(CartProductDeleteRequest request, CancellationToken cancellationToken)
        {
            var cartProduct = await Context
                .FindAsync<CartProduct>(request.KeyValues, cancellationToken)
                .ConfigureAwait(false);
            var cart = await Context
                .FindAsync<Cart>(new object[] { request.CartId }, cancellationToken)
                .ConfigureAwait(false);
            if (cartProduct == null || cart == null) return Unit.Value;

            cart.Total -= cartProduct.ExtendedPrice;
            Context.Entry(cartProduct).State = EntityState.Detached;

            return await base.Handle(request, cancellationToken);
        }
    }
}
