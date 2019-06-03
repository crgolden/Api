namespace crgolden.Api.ProductCategories
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoryDeleteRangeRequestHandler : DeleteRangeRequestHandler<ProductCategoryDeleteRangeRequest, ProductCategory>
    {
        public ProductCategoryDeleteRangeRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
