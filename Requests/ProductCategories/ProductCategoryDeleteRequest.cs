namespace Clarity.Api.ProductCategories
{
    using System;
    using Abstractions;

    public class ProductCategoryDeleteRequest : DeleteRequest
    {
        public readonly Guid ProductId;

        public readonly Guid CategoryId;

        public ProductCategoryDeleteRequest(Guid productId, Guid categoryId) : base(new object[] { productId, categoryId })
        {
            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}
