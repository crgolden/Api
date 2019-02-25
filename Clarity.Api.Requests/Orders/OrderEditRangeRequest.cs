namespace Clarity.Api.Orders
{
    using System.Collections.Generic;
    using Core;

    public class OrderEditRangeRequest : EditRangeRequest<Order, OrderModel>
    {
        public OrderEditRangeRequest(IEnumerable<OrderModel> orders) : base(orders)
        {
        }
    }
}
