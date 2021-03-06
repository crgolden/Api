﻿namespace crgolden.Api.CartProducts
{
    using System;
    using Abstractions;

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
