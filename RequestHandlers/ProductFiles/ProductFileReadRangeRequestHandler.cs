namespace crgolden.Api.ProductFiles
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileReadRangeRequestHandler : ReadRangeRequestHandler<ProductFileReadRangeRequest, ProductFile, ProductFileModel>
    {
        public ProductFileReadRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
