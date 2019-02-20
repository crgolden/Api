namespace Clarity.Api.CartProducts
{
    using System;
    using Core;

    public class CartProductDetailsRequest: DetailsRequest<CartProduct>
    {
        public readonly Guid CartId;

        public readonly Guid ProductId;

        public CartProductDetailsRequest(Guid cartId, Guid productId) : base(new object[] { cartId, productId })
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
