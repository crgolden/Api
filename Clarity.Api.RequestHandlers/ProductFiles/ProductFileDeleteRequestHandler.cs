namespace Clarity.Api.ProductFiles
{
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileDeleteRequestHandler : DeleteRequestHandler<ProductFileDeleteRequest, ProductFile>
    {
        public ProductFileDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
