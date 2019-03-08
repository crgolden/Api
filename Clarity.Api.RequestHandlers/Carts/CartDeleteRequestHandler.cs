namespace Clarity.Api.Carts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CartDeleteRequestHandler : DeleteRequestHandler<CartDeleteRequest, Cart>
    {
        public CartDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override Task<Unit> Handle(CartDeleteRequest request, CancellationToken token)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}
