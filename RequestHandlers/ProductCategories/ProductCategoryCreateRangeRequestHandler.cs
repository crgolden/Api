namespace crgolden.Api.ProductCategories
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryCreateRangeRequestHandler : CreateRangeRequestHandler<ProductCategoryCreateRangeRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
