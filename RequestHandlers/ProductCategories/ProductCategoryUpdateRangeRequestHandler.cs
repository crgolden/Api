namespace crgolden.Api.ProductCategories
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryUpdateRangeRequestHandler : UpdateRangeRequestHandler<ProductCategoryUpdateRangeRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryUpdateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
