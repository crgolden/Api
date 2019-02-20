namespace Clarity.Api.ProductFiles
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileCreateRequestHandler : CreateRequestHandler<ProductFileCreateRequest, ProductFile>
    {
        public ProductFileCreateRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<ProductFile> Handle(ProductFileCreateRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
