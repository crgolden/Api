namespace Clarity.Api.Orders
{
    using System;
    using Core;

    public class OrderDeleteRequest : DeleteRequest
    {
        public readonly Guid OrderId;

        public OrderDeleteRequest(Guid orderId) : base(new object[] { orderId })
        {
            OrderId = orderId;
        }
    }
}
