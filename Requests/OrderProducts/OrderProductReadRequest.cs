namespace crgolden.Api.OrderProducts
{
    using System;
    using Abstractions;

    public class OrderProductReadRequest: ReadRequest<OrderProduct, OrderProductModel>
    {
        public readonly Guid OrderId;

        public readonly Guid ProductId;

        public OrderProductReadRequest(Guid orderId, Guid productId) : base(new object[] { orderId, productId })
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
