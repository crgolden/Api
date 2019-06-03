namespace crgolden.Api.Carts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartDeleteRequestHandler : DeleteRequestHandler<CartDeleteRequest, Cart>
    {
        public CartDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override Task<object[][]> Handle(CartDeleteRequest request, CancellationToken token)
        {
            return Task.FromResult(new object[0][]);
        }
    }
}
