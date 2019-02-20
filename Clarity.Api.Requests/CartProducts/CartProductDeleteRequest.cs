namespace Clarity.Api.CartProducts
{
    using System;
    using Core;

    public class CartProductDeleteRequest : DeleteRequest
    {
        public readonly Guid CartId;

        public readonly Guid ProductId;

        public CartProductDeleteRequest(Guid cartId, Guid productId) : base(new object[] { cartId, productId })
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
