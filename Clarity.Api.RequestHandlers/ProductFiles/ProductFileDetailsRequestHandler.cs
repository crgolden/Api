namespace Clarity.Api.ProductFiles
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileDetailsRequestHandler : DetailsRequestHandler<ProductFileDetailsRequest, ProductFile>
    {
        public ProductFileDetailsRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<ProductFile> Handle(ProductFileDetailsRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
