namespace Clarity.Api.Carts
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartCreateRequestHandler : CreateRequestHandler<CartCreateRequest, Cart>
    {
        public CartCreateRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Cart> Handle(CartCreateRequest request, CancellationToken cancellationToken)
        {
            Cart cart = null;
            if (request.Entity.UserId != null && request.Entity.UserId != Guid.Empty)
            {
                cart = await Context.Set<Cart>()
                    .Include(x => x.CartProducts)
                    .SingleOrDefaultAsync(x => x.UserId == request.Entity.UserId, cancellationToken)
                    .ConfigureAwait(false);
            }

            if (cart == null)
            {
                request.Entity.Total = request.Entity.CartProducts.Sum(x => x.ExtendedPrice);
                return await base.Handle(request, cancellationToken).ConfigureAwait(false);
            }

            foreach (var modelCartProduct in request.Entity.CartProducts)
            {
                var cartProduct = cart.CartProducts.SingleOrDefault(x => x.ProductId == modelCartProduct.ProductId);
                if (cartProduct != null)
                {
                    cartProduct.Price = modelCartProduct.Price;
                    cartProduct.Quantity = modelCartProduct.Quantity;
                }
                else
                {
                    cart.CartProducts.Add(modelCartProduct);
                }
            }

            cart.Total = cart.CartProducts.Sum(x => x.ExtendedPrice);
            return await base.Handle(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
