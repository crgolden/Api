namespace Clarity.Api.CartProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CartProductEditRangeRequestHandler : EditRangeRequestHandler<CartProductEditRangeRequest, CartProduct>
    {
        public CartProductEditRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(CartProductEditRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
