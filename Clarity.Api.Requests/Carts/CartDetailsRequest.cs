namespace Clarity.Api.Carts
{
    using System;
    using Core;

    public class CartDetailsRequest : DetailsRequest<Cart, CartModel>
    {
        public readonly Guid CartId;

        public readonly Guid? UserId;

        public CartDetailsRequest(Guid cartId, Guid? userId = null) : base(new object[] { cartId })
        {
            CartId = cartId;
            if (userId.HasValue) UserId = userId.Value;
        }
    }
}
