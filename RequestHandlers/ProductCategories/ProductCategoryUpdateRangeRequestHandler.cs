namespace Clarity.Api.ProductCategories
{
    using Abstractions;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryUpdateRangeRequestHandler : UpdateRangeRequestHandler<ProductCategoryUpdateRangeRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryUpdateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
