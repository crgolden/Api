namespace Clarity.Api.Products
{
    using System;
    using Core;

    public class ProductDetailsRequest : DetailsRequest<Product, ProductModel>
    {
        public readonly Guid ProductId;

        public bool Active { get; set; }

        public ProductDetailsRequest(Guid productId) : base(new object[] { productId })
        {
            ProductId = productId;
        }
    }
}
