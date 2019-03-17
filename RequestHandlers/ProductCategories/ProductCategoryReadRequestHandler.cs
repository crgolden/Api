namespace Clarity.Api.ProductCategories
{
    using Abstractions;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryReadRequestHandler : ReadRequestHandler<ProductCategoryReadRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryReadRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
