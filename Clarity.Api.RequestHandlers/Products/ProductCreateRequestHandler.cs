namespace Clarity.Api.Products
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductCreateRequestHandler : CreateRequestHandler<ProductCreateRequest, Product>
    {
        public ProductCreateRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Product> Handle(ProductCreateRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
