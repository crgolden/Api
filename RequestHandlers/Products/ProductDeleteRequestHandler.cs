namespace crgolden.Api.Products
{
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductDeleteRequestHandler : DeleteRequestHandler<ProductDeleteRequest, Product>
    {
        public ProductDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override Task<object[][]> Handle(ProductDeleteRequest request, CancellationToken token)
        {
            return Task.FromResult(new object[0][]);
        }
    }
}
