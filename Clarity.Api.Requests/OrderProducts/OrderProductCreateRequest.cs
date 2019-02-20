namespace Clarity.Api.OrderProducts
{
    using Core;

    public class OrderProductCreateRequest : CreateRequest<OrderProduct>
    {
        public OrderProductCreateRequest(OrderProduct orderProduct) : base(orderProduct)
        {
        }
    }
}
