namespace crgolden.Api.Orders
{
    using Abstractions;

    public class OrderCreateRequest : CreateRequest<Order, OrderModel>
    {
        public OrderCreateRequest(OrderModel order) : base(order)
        {
        }
    }
}
