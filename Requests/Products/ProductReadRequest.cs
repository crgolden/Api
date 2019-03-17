namespace Clarity.Api.Products
{
    using System;
    using Abstractions;

    public class ProductReadRequest : ReadRequest<Product, ProductModel>
    {
        public readonly Guid ProductId;

        public bool Active { get; set; }

        public ProductReadRequest(Guid productId) : base(new object[] { productId })
        {
            ProductId = productId;
        }
    }
}
