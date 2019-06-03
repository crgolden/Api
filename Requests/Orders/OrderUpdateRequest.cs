namespace crgolden.Api.Orders
{
    using Abstractions;

    public class OrderUpdateRequest : UpdateRequest<Order, OrderModel>
    {
        public OrderUpdateRequest(OrderModel order) : base(order)
        {
        }
    }
}
