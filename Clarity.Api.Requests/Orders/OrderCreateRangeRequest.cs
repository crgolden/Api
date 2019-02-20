namespace Clarity.Api.Orders
{
    using System.Collections.Generic;
    using Core;

    public class OrderCreateRangeRequest : CreateRangeRequest<IEnumerable<Order>, Order>
    {
        public OrderCreateRangeRequest(IEnumerable<Order> orders) : base(orders)
        {
        }
    }
}
