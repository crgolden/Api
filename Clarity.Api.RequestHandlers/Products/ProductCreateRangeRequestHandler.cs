namespace Clarity.Api.Products
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductCreateRangeRequestHandler
        : CreateRangeRequestHandler<ProductCreateRangeRequest, IEnumerable<Product>, Product>
    {
        public ProductCreateRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Product>> Handle(ProductCreateRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
