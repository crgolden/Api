namespace crgolden.Api.ProductFiles
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileCreateRequestHandler : CreateRequestHandler<ProductFileCreateRequest, ProductFile, ProductFileModel>
    {
        public ProductFileCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
