namespace Clarity.Api.ProductCategories
{
    using Abstractions;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryReadRangeRequestHandler : ReadRangeRequestHandler<ProductCategoryReadRangeRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryReadRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
