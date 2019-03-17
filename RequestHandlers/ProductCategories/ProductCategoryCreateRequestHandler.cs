namespace Clarity.Api.ProductCategories
{
    using Abstractions;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryCreateRequestHandler : CreateRequestHandler<ProductCategoryCreateRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
