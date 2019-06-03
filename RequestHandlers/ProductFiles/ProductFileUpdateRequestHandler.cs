namespace crgolden.Api.ProductFiles
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileUpdateRequestHandler : UpdateRequestHandler<ProductFileUpdateRequest, ProductFile, ProductFileModel>
    {
        public ProductFileUpdateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
