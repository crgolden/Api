namespace Clarity.Api.Orders
{
    using System;
    using Abstractions;

    public class OrderReadRequest : ReadRequest<Order, OrderModel>
    {
        public readonly Guid OrderId;

        public Guid? UserId { get; set; }

        public OrderReadRequest(Guid orderId) : base(new object[] { orderId })
        {
            OrderId = orderId;
        }
    }
}
