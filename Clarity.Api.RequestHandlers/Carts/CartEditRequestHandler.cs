namespace Clarity.Api.Carts
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CartEditRequestHandler : EditRequestHandler<CartEditRequest, Cart>
    {
        public CartEditRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(CartEditRequest request, CancellationToken cancellationToken)
        {
            if (request.Entity.UserId.HasValue)
            {
                var cart = await Context.Set<Cart>()
                    .Include(x => x.CartProducts)
                    .SingleOrDefaultAsync(x => x.UserId == request.Entity.UserId.Value, cancellationToken)
                    .ConfigureAwait(false);
                if (cart != null)
                {
                    if (cart.Id != request.Entity.Id)
                    {
                        foreach (var cartProduct in cart.CartProducts.Where(x => request.Entity.CartProducts.All(y => x.ProductId != y.ProductId)))
                        {
                            request.Entity.CartProducts.Add(cartProduct);
                        }

                        Context.Remove(cart);
                    }
                    else
                    {
                        Context.Entry(cart).State = EntityState.Detached;
                    }
                }
            }

            var cartProducts = Context.Set<CartProduct>().Where(x => x.CartId == request.Entity.Id);
            foreach (var cartProduct in request.Entity.CartProducts)
            {
                var existing = await cartProducts
                    .SingleOrDefaultAsync(x => x.ProductId == cartProduct.ProductId, cancellationToken)
                    .ConfigureAwait(false);
                if (existing != null && existing.Quantity != cartProduct.Quantity)
                {
                    existing.Quantity = cartProduct.Quantity;
                }
                else
                {
                    Context.Add(cartProduct);
                }
            }

            foreach (var cartProduct in cartProducts.Where(x => request.Entity.CartProducts.All(y => x.ProductId != y.ProductId)))
            {
                Context.Remove(cartProduct);
            }

            request.Entity.Total = request.Entity.CartProducts.Sum(x => x.ExtendedPrice);

            return await base.Handle(request, cancellationToken);
        }
    }
}
