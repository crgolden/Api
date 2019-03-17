namespace Clarity.Api.ProductCategories
{
    using System;
    using Abstractions;

    public class ProductCategoryReadRequest: ReadRequest<ProductCategory, ProductCategoryModel>
    {
        public readonly Guid ProductId;

        public readonly Guid CategoryId;

        public ProductCategoryReadRequest(Guid productId, Guid categoryId) : base(new object[] { productId, categoryId })
        {
            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}
