namespace Clarity.Api.OrderProducts
{
    using System;
    using Core;

    public class OrderProductDeleteRequest : DeleteRequest
    {
        public readonly Guid OrderId;

        public readonly Guid ProductId;

        public OrderProductDeleteRequest(Guid orderId, Guid productId) : base(new object[] { orderId, productId })
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
