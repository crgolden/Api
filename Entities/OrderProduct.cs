namespace crgolden.Api
{
    using System;
    using Abstractions;

    public class OrderProduct : Entity
    {
        public decimal Quantity { get; set; }

        public Guid OrderId { get; private set; }

        public virtual Order Order { get; private set; }

        public Guid ProductId { get; private set; }

        public virtual Product Product { get; private set; }

        public OrderProduct(Guid orderId, Guid productId, decimal quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
