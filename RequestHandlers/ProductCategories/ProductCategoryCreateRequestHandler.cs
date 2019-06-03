namespace crgolden.Api.ProductCategories
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryCreateRequestHandler : CreateRequestHandler<ProductCategoryCreateRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
