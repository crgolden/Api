namespace Clarity.Api.Products
{
    using System;
    using Core;

    public class ProductDeleteRequest : DeleteRequest
    {
        public readonly Guid ProductId;

        public ProductDeleteRequest(Guid productId) : base(new object[] { productId })
        {
            ProductId = productId;
        }
    }
}
