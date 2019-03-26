namespace Clarity.Api.Carts
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartCreateRequestHandler : CreateRequestHandler<CartCreateRequest, Cart, CartModel>
    {
        public CartCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<(CartModel, object[])> Handle(CartCreateRequest request, CancellationToken token)
        {
            if (request.Model.UserId == null) return await base.Handle(request, token).ConfigureAwait(false);
            var cart = await Context.Set<Cart>()
                .Include(x => x.CartProducts)
                .SingleOrDefaultAsync(x => x.UserId == request.Model.UserId, token)
                .ConfigureAwait(false);
            return cart != null
                ? (Mapper.Map<CartModel>(cart), new object[]{ cart.Id })
                : await base.Handle(request, token).ConfigureAwait(false);
        }
    }
}
