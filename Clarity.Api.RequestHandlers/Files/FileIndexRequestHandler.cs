namespace Clarity.Api.Files
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;
    using Products;

    public class ProductIndexRequestHandler : IndexRequestHandler<ProductIndexRequest, File>
    {
        public ProductIndexRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<DataSourceResult> Handle(ProductIndexRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
