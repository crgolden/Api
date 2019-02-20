namespace Clarity.Api.Orders
{
    using Core;

    public class OrderEditRequest : EditRequest<Order>
    {
        public OrderEditRequest(Order order) : base(order)
        {
        }
    }
}
