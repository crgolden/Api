namespace Clarity.Api.OrderProducts
{
    using System;
    using Core;

    public class OrderProductDetailsRequest: DetailsRequest<OrderProduct>
    {
        public readonly Guid OrderId;

        public readonly Guid ProductId;

        public OrderProductDetailsRequest(Guid orderId, Guid productId) : base(new object[] { orderId, productId })
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
