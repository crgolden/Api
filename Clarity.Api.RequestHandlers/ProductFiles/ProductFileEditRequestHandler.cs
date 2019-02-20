namespace Clarity.Api.ProductFiles
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileEditRequestHandler : EditRequestHandler<ProductFileEditRequest, ProductFile>
    {
        public ProductFileEditRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(ProductFileEditRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
