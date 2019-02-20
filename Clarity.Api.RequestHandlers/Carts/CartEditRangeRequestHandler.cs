namespace Clarity.Api.Carts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CartEditRangeRequestHandler : EditRangeRequestHandler<CartEditRangeRequest, Cart>
    {
        public CartEditRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(CartEditRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
