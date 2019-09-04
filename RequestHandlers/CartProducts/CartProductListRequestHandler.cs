namespace crgolden.Api.CartProducts
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

    public class CartProductListRequestHandler : ListRequestHandler<CartProductListRequest, CartProduct, CartProductModel>
    {
        private readonly IStorageService _storageService;
        private readonly StorageOptions _storageOptions;

        public CartProductListRequestHandler(
            DbContext context,
            IMapper mapper,
            IStorageService storageService,
            IOptions<StorageOptions> storageOptions) : base(context, mapper)
        {
            _storageService = storageService;
            _storageOptions = storageOptions.Value;
        }

        public override Task<IQueryable<CartProductModel>> Handle(CartProductListRequest request, CancellationToken token)
        {
            var cartProducts = Context.Set<CartProduct>()
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductFiles)
                .ThenInclude(x => x.File)
                .AsNoTracking();
            return Task.FromResult(request.Options
                .ApplyTo(cartProducts)
                .Cast<CartProduct>()
                .AsEnumerable()
                .Select(cartProduct =>
                {
                    var model = Mapper.Map<CartProductModel>(cartProduct);
                    var productFile = cartProduct.Product.ProductFiles
                        .SingleOrDefault(x => x.File.ContentType.Contains("image") && x.IsPrimary);
                    if (productFile == null) return model;
                    model.ProductImageThumbnailUri = productFile.File.GetImageFileUri(
                        storageService: _storageService,
                        options: _storageOptions,
                        thumbnail: true);
                    return model;
                })
                .AsQueryable());
        }
    }
}
