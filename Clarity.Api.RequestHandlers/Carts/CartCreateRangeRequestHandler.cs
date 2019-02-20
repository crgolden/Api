namespace Clarity.Api.Carts
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartCreateRangeRequestHandler : CreateRangeRequestHandler<CartCreateRangeRequest, IEnumerable<Cart>, Cart>
    {
        public CartCreateRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Cart>> Handle(CartCreateRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
