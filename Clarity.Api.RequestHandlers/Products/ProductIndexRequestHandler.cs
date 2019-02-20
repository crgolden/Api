namespace Clarity.Api.Products
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;

    public class ProductIndexRequestHandler : IndexRequestHandler<ProductIndexRequest, Product>
    {
        private readonly IStorageService _storageService;

        public ProductIndexRequestHandler(DbContext context, IStorageService storageService) : base(context)
        {
            _storageService = storageService;
        }

        public override async Task<DataSourceResult> Handle(ProductIndexRequest request, CancellationToken cancellationToken)
        {
            var products = request.Active
                ? Context.Set<Product>().Where(x => x.Active)
                : Context.Set<Product>();
            return await products
                .Include(x => x.ProductFiles)
                .ThenInclude(x => x.File)
                .AsNoTracking()
                .ToDataSourceResultAsync(request.Request, request.ModelState, product =>
                {
                    if (!product.ProductFiles.Any())
                    {
                        return product;
                    }

                    foreach (var productFile in product.ProductFiles)
                    {
                        var sharedAccessToken = _storageService.GetSharedAccessSignature(
                            fileName: productFile.File.FileName,
                            uri: productFile.Uri);
                        productFile.Uri += sharedAccessToken;
                    }

                    return product;
                })
                .ConfigureAwait(false);
        }
    }
}
