namespace Clarity.Api.ProductCategories
{
    using Abstractions;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryCreateRangeRequestHandler : CreateRangeRequestHandler<ProductCategoryCreateRangeRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
