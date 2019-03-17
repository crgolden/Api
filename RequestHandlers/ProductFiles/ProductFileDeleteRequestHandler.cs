namespace Clarity.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileDeleteRequestHandler : DeleteRequestHandler<ProductFileDeleteRequest, ProductFile>
    {
        public ProductFileDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
