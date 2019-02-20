namespace Clarity.Api.CartProducts
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartProductCreateRangeRequestHandler
        : CreateRangeRequestHandler<CreateRangeRequest<IEnumerable<CartProduct>, CartProduct>, IEnumerable<CartProduct>, CartProduct>
    {
        public CartProductCreateRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<CartProduct>> Handle(CreateRangeRequest<IEnumerable<CartProduct>, CartProduct> request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
