namespace Clarity.Api.Products
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ProductEditRequestHandler : EditRequestHandler<ProductEditRequest, Product>
    {
        public ProductEditRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(ProductEditRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
