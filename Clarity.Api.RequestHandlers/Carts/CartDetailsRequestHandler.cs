namespace Clarity.Api.Carts
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartDetailsRequestHandler : DetailsRequestHandler<CartDetailsRequest, Cart, CartModel>
    {
        public CartDetailsRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<CartModel> Handle(CartDetailsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var cart = await Context.Set<Cart>()
                           .SingleOrDefaultAsync(x => x.Id == request.CartId || x.UserId == request.UserId, cancellationToken)
                           .ConfigureAwait(false);
            return cart == null
                ? await base.Handle(request, cancellationToken).ConfigureAwait(false)
                : Mapper.Map<CartModel>(cart);
        }
    }
}
