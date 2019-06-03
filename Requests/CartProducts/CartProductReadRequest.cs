namespace crgolden.Api.CartProducts
{
    using System;
    using Abstractions;

    public class CartProductReadRequest: ReadRequest<CartProduct, CartProductModel>
    {
        public readonly Guid CartId;

        public readonly Guid ProductId;

        public CartProductReadRequest(Guid cartId, Guid productId) : base(new object[] { cartId, productId })
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
