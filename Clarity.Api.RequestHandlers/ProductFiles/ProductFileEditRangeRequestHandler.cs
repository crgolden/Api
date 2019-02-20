namespace Clarity.Api.ProductFiles
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileEditRangeRequestHandler : EditRangeRequestHandler<ProductFileEditRangeRequest, ProductFile>
    {
        public ProductFileEditRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(ProductFileEditRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
