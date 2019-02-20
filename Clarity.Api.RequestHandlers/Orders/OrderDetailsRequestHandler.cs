namespace Clarity.Api.Orders
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderDetailsRequestHandler : DetailsRequestHandler<OrderDetailsRequest, Order>
    {
        private readonly IStorageService _storageService;

        public OrderDetailsRequestHandler(DbContext context, IStorageService storageService) : base(context)
        {
            _storageService = storageService;
        }

        public override async Task<Order> Handle(OrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var orders = Context.Set<Order>()
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.ProductFiles)
                .ThenInclude(x => x.File)
                .Include(x => x.Payments)
                .AsNoTracking();
            if (request.UserId.HasValue) orders = orders.Where(x => x.UserId == request.UserId.Value);
            var order = await orders
                    .SingleOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken)
                    .ConfigureAwait(false);
            if (order == null ||
                !order.OrderProducts.Any(x => x.Product.ProductFiles.Any(y => y.ContentType.Contains("image") && y.Primary)))
            {
                return order;
            }

            foreach (var orderProduct in order.OrderProducts.Where(x => x.Product.ProductFiles.Any(y => y.ContentType.Contains("image") && y.Primary)))
            {
                var file = orderProduct.Product.ProductFiles.Single(x => x.ContentType.Contains("image") && x.Primary).File;
                var sharedAccessSignature = _storageService.GetSharedAccessSignature(file.FileName, file.Uri);
                orderProduct.ThumbnailUri = $"{file.Uri.Replace("images/", "thumbnails/")}{sharedAccessSignature}";
            }

            return order;
        }
    }
}
