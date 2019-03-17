namespace Clarity.Api.Carts
{
    using System;
    using Abstractions;

    public class CartReadRequest : ReadRequest<Cart, CartModel>
    {
        public readonly Guid CartId;

        public readonly Guid? UserId;

        public CartReadRequest(Guid cartId, Guid? userId = null) : base(new object[] { cartId })
        {
            CartId = cartId;
            if (userId.HasValue) UserId = userId.Value;
        }
    }
}
