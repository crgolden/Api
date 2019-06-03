namespace crgolden.Api.ProductCategories
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryReadRangeRequestHandler : ReadRangeRequestHandler<ProductCategoryReadRangeRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryReadRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
