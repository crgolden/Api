namespace Clarity.Api.ProductCategories
{
    using Abstractions;

    public class ProductCategoryUpdateRequest : UpdateRequest<ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryUpdateRequest(ProductCategoryModel productCategory) : base(productCategory)
        {
        }
    }
}
