namespace Clarity.Api.Orders
{
    using Core;

    public class OrderCreateRequest : CreateRequest<Order>
    {
        public string Email { get; set; }

        public string CustomerCode { get; set; }

        public OrderCreateRequest(Order order) : base(order)
        {
        }
    }
}
