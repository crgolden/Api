﻿namespace crgolden.Api.Orders
{
    using System;
    using Abstractions;

    public class OrderDeleteRequest : DeleteRequest
    {
        public readonly Guid OrderId;

        public OrderDeleteRequest(Guid orderId) : base(new object[] { orderId })
        {
            OrderId = orderId;
        }
    }
}
