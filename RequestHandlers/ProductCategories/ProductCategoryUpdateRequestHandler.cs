namespace Clarity.Api.ProductCategories
{
    using Abstractions;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryUpdateRequestHandler : UpdateRequestHandler<ProductCategoryUpdateRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryUpdateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
