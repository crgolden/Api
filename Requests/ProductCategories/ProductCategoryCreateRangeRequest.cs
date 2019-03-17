namespace Clarity.Api.ProductCategories
{
    using Abstractions;

    public class ProductCategoryCreateRangeRequest : CreateRangeRequest<ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryCreateRangeRequest(ProductCategoryModel[] productCategories) : base(productCategories)
        {
        }
    }
}
