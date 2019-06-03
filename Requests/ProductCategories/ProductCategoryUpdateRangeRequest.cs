namespace crgolden.Api.ProductCategories
{
    using Abstractions;

    public class ProductCategoryUpdateRangeRequest : UpdateRangeRequest<ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryUpdateRangeRequest(ProductCategoryModel[] productCategories) : base(productCategories)
        {

        }
    }
}
