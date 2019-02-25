namespace Clarity.Api.Orders
{
    using Core;

    public class OrderEditRequest : EditRequest<Order, OrderModel>
    {
        public OrderEditRequest(OrderModel order) : base(order)
        {
        }
    }
}
