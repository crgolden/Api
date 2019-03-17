namespace Clarity.Api.OrderProducts
{
    using Abstractions;

    public class OrderProductCreateRequest : CreateRequest<OrderProduct, OrderProductModel>
    {
        public OrderProductCreateRequest(OrderProductModel orderProduct) : base(orderProduct)
        {
        }
    }
}
