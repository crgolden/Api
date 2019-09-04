namespace crgolden.Api.Orders
{
    using System;
    using Abstractions;
    using Microsoft.AspNet.OData.Query;

    public class OrderListRequest : ListRequest<Order, OrderModel>
    {
        public Guid? UserId { get; set; }

        public OrderListRequest(ODataQueryOptions<OrderModel> options) : base(options)
        {
        }
    }
}
