namespace crgolden.Api.OrderProducts
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

    public class OrderProductListRequestHandler : ListRequestHandler<OrderProductListRequest, OrderProduct, OrderProductModel>
    {
        private readonly IStorageService _storageService;
        private readonly StorageOptions _storageOptions;

        public OrderProductListRequestHandler(
            DbContext context,
            IMapper mapper,
            IStorageService storageService,
            IOptions<StorageOptions> storageOptions) : base(context, mapper)
        {
            _storageService = storageService;
            _storageOptions = storageOptions.Value;
        }

        public override Task<IQueryable<OrderProductModel>> Handle(OrderProductListRequest request, CancellationToken token)
        {
            var orders = request.UserId.HasValue
                ? Context.Set<OrderProduct>().Where(x => x.Order.UserId == request.UserId.Value)
                : Context.Set<OrderProduct>();
            return Task.FromResult(request.Options
                .ApplyTo(orders
                    .Include(x => x.Order)
                    .Include(x => x.Product)
                    .ThenInclude(x => x.ProductFiles)
                    .ThenInclude(x => x.File)
                    .AsNoTracking())
                .Cast<OrderProduct>()
                .AsEnumerable()
                .Select(orderProduct =>
                {
                    var model = Mapper.Map<OrderProductModel>(orderProduct);
                    var productFile = orderProduct.Product.ProductFiles
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
