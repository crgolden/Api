namespace Clarity.Api.ProductFiles
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileDeleteRequestHandler : DeleteRequestHandler<ProductFileDeleteRequest, ProductFile>
    {
        public ProductFileDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(ProductFileDeleteRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
