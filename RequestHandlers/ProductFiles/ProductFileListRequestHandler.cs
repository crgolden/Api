namespace crgolden.Api.ProductFiles
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileListRequestHandler : ListRequestHandler<ProductFileListRequest, ProductFile, ProductFileModel>
    {
        public ProductFileListRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
