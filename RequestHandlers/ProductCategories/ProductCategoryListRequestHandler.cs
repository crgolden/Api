namespace crgolden.Api.ProductCategories
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryListRequestHandler : ListRequestHandler<ProductCategoryListRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryListRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
