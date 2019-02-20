namespace Clarity.Api.Carts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartDetailsRequestHandler : DetailsRequestHandler<CartDetailsRequest, Cart>
    {
        private readonly IStorageService _storageService;

        public CartDetailsRequestHandler(DbContext context, IStorageService storageService) : base(context)
        {
            _storageService = storageService;
        }

        public override async Task<Cart> Handle(CartDetailsRequest request, CancellationToken cancellationToken)
        {
            var cart = await Context.Set<Cart>()
                           .Include(x => x.CartProducts)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.ProductFiles)
                           .ThenInclude(x => x.File)
                           .SingleOrDefaultAsync(x => x.Id == request.CartId ||
                                                      x.UserId.HasValue && x.UserId.Value == request.UserId, cancellationToken)
                           .ConfigureAwait(false);
            if (cart == null)
            {
                cart = new Cart(request.CartId, request.UserId)
                {
                    CartProducts = new List<CartProduct>()
                };
                Context.Add(cart);
                await Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            foreach (var cartProduct in cart.CartProducts.Where(x =>
                x.Product.ProductFiles.SingleOrDefault(y => y.ContentType.Contains("image") && y.Primary) != null))
            {
                var file = cartProduct.Product.ProductFiles.Single(z => z.ContentType.Contains("image") && z.Primary).File;
                var sharedAccessSignature = _storageService.GetSharedAccessSignature(file.FileName, file.Uri);
                cartProduct.ThumbnailUri = $"{file.Uri.Replace("images/", "thumbnails/")}{sharedAccessSignature}";
            }

            return cart;
        }
    }
}
