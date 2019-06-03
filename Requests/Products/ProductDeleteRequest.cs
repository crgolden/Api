namespace crgolden.Api.Products
{
    using System;
    using Abstractions;

    public class ProductDeleteRequest : DeleteRequest
    {
        public readonly Guid ProductId;

        public ProductDeleteRequest(Guid productId) : base(new object[] { productId })
        {
            ProductId = productId;
        }
    }
}
