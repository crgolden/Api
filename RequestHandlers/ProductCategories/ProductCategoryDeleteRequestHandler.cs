namespace crgolden.Api.ProductCategories
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryDeleteRequestHandler : DeleteRequestHandler<ProductCategoryDeleteRequest, ProductCategory>
    {
        public ProductCategoryDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
