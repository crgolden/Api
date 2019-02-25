namespace Clarity.Api
{
    using System;
    using Core;

    public class CartProduct : Entity
    {
        public decimal Quantity { get; set; }

        public Guid CartId { get; private set; }

        public virtual Cart Cart { get; private set; }

        public Guid ProductId { get; private set; }

        public virtual Product Product {get; private set;}

        public CartProduct(Guid cartId, Guid productId)
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
