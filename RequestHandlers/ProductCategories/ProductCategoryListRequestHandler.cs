namespace Clarity.Api.ProductCategories
{
    using Abstractions;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryListRequestHandler : ListRequestHandler<ProductCategoryListRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryListRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
