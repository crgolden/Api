namespace Clarity.Api.ProductFiles
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileCreateRangeRequestHandler : CreateRangeRequestHandler<ProductFileCreateRangeRequest, IEnumerable<ProductFile>, ProductFile>
    {
        public ProductFileCreateRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<ProductFile>> Handle(ProductFileCreateRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
