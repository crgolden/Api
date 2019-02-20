namespace Clarity.Api.Orders
{
    using System.Collections.Generic;
    using Core;

    public class OrderEditRangeRequest : EditRangeRequest<Order>
    {
        public OrderEditRangeRequest(IEnumerable<Order> orders) : base(orders)
        {
        }
    }
}
