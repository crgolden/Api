namespace Clarity.Api.CartProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CartProductEditRequestHandler : EditRequestHandler<CartProductEditRequest, CartProduct>
    {
        public CartProductEditRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(CartProductEditRequest request, CancellationToken cancellationToken)
        {
            var cartProduct = await Context
                .FindAsync<CartProduct>(new object[] { request.Entity.CartId, request.Entity.ProductId }, cancellationToken)
                .ConfigureAwait(false);
            var cart = await Context
                .FindAsync<Cart>(new object[] { request.Entity.CartId }, cancellationToken)
                .ConfigureAwait(false);
            if (cartProduct == null || cart == null) return Unit.Value;

            cart.Total -= cartProduct.ExtendedPrice;
            cart.Total += request.Entity.ExtendedPrice;
            Context.Entry(cartProduct).State = EntityState.Detached;

            return await base.Handle(request, cancellationToken);
        }
    }
}
