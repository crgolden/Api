namespace crgolden.Api.ProductCategories
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryReadRequestHandler : ReadRequestHandler<ProductCategoryReadRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryReadRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
