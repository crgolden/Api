namespace Clarity.Api.Orders
{
    using System;
    using Core;

    public class OrderDetailsRequest : DetailsRequest<Order>
    {
        public readonly Guid OrderId;

        public Guid? UserId { get; set; }

        public OrderDetailsRequest(Guid orderId) : base(new object[] { orderId })
        {
            OrderId = orderId;
        }
    }
}
