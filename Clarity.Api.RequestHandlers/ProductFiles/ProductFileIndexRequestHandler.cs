namespace Clarity.Api.ProductFiles
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileIndexRequestHandler : IndexRequestHandler<ProductFileIndexRequest, ProductFile>
    {
        public ProductFileIndexRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<DataSourceResult> Handle(ProductFileIndexRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
