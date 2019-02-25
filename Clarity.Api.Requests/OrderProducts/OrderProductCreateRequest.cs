namespace Clarity.Api.OrderProducts
{
    using Core;

    public class OrderProductCreateRequest : CreateRequest<OrderProduct, OrderProductModel>
    {
        public OrderProductCreateRequest(OrderProductModel orderProduct) : base(orderProduct)
        {
        }
    }
}
