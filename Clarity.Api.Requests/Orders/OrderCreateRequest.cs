namespace Clarity.Api.Orders
{
    using Core;

    public class OrderCreateRequest : CreateRequest<Order, OrderModel>
    {
        public OrderCreateRequest(OrderModel order) : base(order)
        {
        }
    }
}
