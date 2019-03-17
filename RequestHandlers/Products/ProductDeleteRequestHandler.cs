namespace Clarity.Api.Products
{
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ProductDeleteRequestHandler : DeleteRequestHandler<ProductDeleteRequest, Product>
    {
        public ProductDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override Task<Unit> Handle(ProductDeleteRequest request, CancellationToken token)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}
