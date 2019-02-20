namespace Clarity.Api.Products
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductDetailsRequestHandler : DetailsRequestHandler<ProductDetailsRequest, Product>
    {
        private readonly IStorageService _storageService;

        public ProductDetailsRequestHandler(DbContext context, IStorageService storageService) : base(context)
        {
            _storageService = storageService;
        }

        public override async Task<Product> Handle(ProductDetailsRequest request, CancellationToken cancellationToken)
        {
            var products = Context.Set<Product>()
                .Include(x => x.ProductFiles)
                .ThenInclude(x => x.File)
                .AsNoTracking();
            var product = request.Active
                ? await products
                    .SingleOrDefaultAsync(x => x.Id == request.ProductId && x.Active, cancellationToken)
                    .ConfigureAwait(false)
                : await products
                    .SingleOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
                    .ConfigureAwait(false);
            if (product == null || !product.ProductFiles.Any()) return product;

            foreach (var productFile in product.ProductFiles)
            {
                var sharedAccessToken = _storageService.GetSharedAccessSignature(
                    fileName: productFile.File.FileName,
                    uri: productFile.Uri);
                productFile.Uri += sharedAccessToken;
            }

            return product;
        }
    }
}
