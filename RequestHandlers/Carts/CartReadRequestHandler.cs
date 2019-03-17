namespace Clarity.Api.Carts
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartReadRequestHandler : ReadRequestHandler<CartReadRequest, Cart, CartModel>
    {
        public CartReadRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<CartModel> Handle(CartReadRequest request, CancellationToken token)
        {
            var carts = Context.Set<Cart>()
                .Include(x => x.CartProducts)
                .ThenInclude(x => x.Product);
            var cart = await carts
                .SingleOrDefaultAsync(x => x.Id == request.CartId, token)
                .ConfigureAwait(false);
            if (cart == null)
            {
                cart = new Cart(request.CartId, request.UserId);
                if (cart.UserId.HasValue)
                {
                    await MergeExistingCart(cart, carts, token).ConfigureAwait(false);
                }

                Context.Add(cart);
                await Context.SaveChangesAsync(token).ConfigureAwait(false);
                return Mapper.Map<CartModel>(cart);
            }

            if (cart.UserId.HasValue || !request.UserId.HasValue)
            {
                return Mapper.Map<CartModel>(cart);
            }

            cart.UserId = request.UserId.Value;
            await MergeExistingCart(cart, carts, token).ConfigureAwait(false);
            await Context.SaveChangesAsync(token).ConfigureAwait(false);
            return Mapper.Map<CartModel>(cart);
        }

        private async Task MergeExistingCart(
            Cart cart,
            IQueryable<Cart> carts,
            CancellationToken token)
        {
            var existingCart = await carts
                .SingleOrDefaultAsync(x => x.UserId == cart.UserId, token)
                .ConfigureAwait(false);
            if (existingCart == null) return;
            foreach (var cartProduct in existingCart.CartProducts
                .Where(x => cart.CartProducts.All(y => y.ProductId != x.ProductId))
                .Select(x => new CartProduct(cart.Id, x.ProductId)))
            {
                cart.AddCartProduct(cartProduct);
            }

            Context.Remove(existingCart);
        }
    }
}
