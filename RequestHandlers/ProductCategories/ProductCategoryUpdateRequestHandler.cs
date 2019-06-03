namespace crgolden.Api.ProductCategories
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryUpdateRequestHandler : UpdateRequestHandler<ProductCategoryUpdateRequest, ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryUpdateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
