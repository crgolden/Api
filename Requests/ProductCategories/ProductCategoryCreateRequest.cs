namespace crgolden.Api.ProductCategories
{
    using Abstractions;

    public class ProductCategoryCreateRequest : CreateRequest<ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryCreateRequest(ProductCategoryModel productCategory) : base(productCategory)
        {
        }
    }
}
