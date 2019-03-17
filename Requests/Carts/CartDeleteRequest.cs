namespace Clarity.Api.Carts
{
    using System;
    using Abstractions;

    public class CartDeleteRequest : DeleteRequest
    {
        public readonly Guid CartId;

        public CartDeleteRequest(Guid cartId) : base(new object[] { cartId })
        {
            CartId = cartId;
        }
    }
}
