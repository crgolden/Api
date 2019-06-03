namespace crgolden.Api.Products
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductUpdateRequestHandler : UpdateRequestHandler<ProductUpdateRequest, Product, ProductModel>
    {
        public ProductUpdateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
