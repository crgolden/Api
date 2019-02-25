namespace Clarity.Api.Carts
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartCreateRequestHandler : CreateRequestHandler<CartCreateRequest, Cart, CartModel>
    {
        public CartCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<CartModel> Handle(CartCreateRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (request.Model.UserId == null)
            {
                return await base.Handle(request, cancellationToken).ConfigureAwait(false);
            }

            var cart = await Context.Set<Cart>()
                .Include(x => x.CartProducts)
                .SingleOrDefaultAsync(x => x.UserId == request.Model.UserId, cancellationToken)
                .ConfigureAwait(false);
            if (cart != null)
            {
                return Mapper.Map<CartModel>(cart);
            }

            return await base.Handle(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
