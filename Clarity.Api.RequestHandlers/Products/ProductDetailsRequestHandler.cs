namespace Clarity.Api.Products
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductDetailsRequestHandler : DetailsRequestHandler<ProductDetailsRequest, Product, ProductModel>
    {
        public ProductDetailsRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ProductModel> Handle(ProductDetailsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var products = Context.Set<Product>().AsNoTracking();
            var product = request.Active
                ? await products
                    .SingleOrDefaultAsync(x => x.Id == request.ProductId && x.Active, cancellationToken)
                    .ConfigureAwait(false)
                : await products
                    .SingleOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
                    .ConfigureAwait(false);
            return product == null
                ? null
                : Mapper.Map<ProductModel>(product);
        }
    }
}
