namespace crgolden.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileDeleteRangeRequestHandler : DeleteRangeRequestHandler<ProductFileDeleteRangeRequest, ProductFile>
    {
        public ProductFileDeleteRangeRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
