namespace Clarity.Api.Orders
{
    using System.Collections.Generic;
    using Core;

    public class OrderCreateRangeRequest : CreateRangeRequest<IEnumerable<OrderModel>, Order, OrderModel>
    {
        public OrderCreateRangeRequest(IEnumerable<OrderModel> orders) : base(orders)
        {
        }
    }
}
