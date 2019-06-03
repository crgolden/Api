namespace crgolden.Api.Products
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Core;
    using Shared;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    public class ProductReadRequestHandler : ReadRequestHandler<ProductReadRequest, Product, ProductModel>
    {
        private readonly IStorageService _storageService;
        private readonly StorageOptions _storageOptions;

        public ProductReadRequestHandler(
            DbContext context,
            IMapper mapper,
            IStorageService storageService,
            IOptions<StorageOptions> storageOptions) : base(context, mapper)
        {
            _storageService = storageService;
            _storageOptions = storageOptions.Value;
        }

        public override async Task<ProductModel> Handle(ProductReadRequest request, CancellationToken token)
        {
            var products = Context.Set<Product>()
                .Include(x => x.ProductFiles)
                .ThenInclude(x => x.File)
                .AsNoTracking();
            var product = request.Active
                ? await products
                    .SingleOrDefaultAsync(x => x.Id == request.ProductId && x.Active, token)
                    .ConfigureAwait(false)
                : await products
                    .SingleOrDefaultAsync(x => x.Id == request.ProductId, token)
                    .ConfigureAwait(false);
            if (product == null) return null;
            var model = Mapper.Map<ProductModel>(product);
            var productFile = product.ProductFiles
                .SingleOrDefault(x => x.File.ContentType.Contains("image") && x.IsPrimary);
            if (productFile == null) return model;
            model.ImageUri = productFile.File.GetImageFileUri(_storageService, _storageOptions);
            return model;
        }
    }
}
