namespace Clarity.Api.OrderProducts
{
    using Abstractions;

    public class OrderProductUpdateRequest : UpdateRequest<OrderProduct, OrderProductModel>
    {
        public OrderProductUpdateRequest(OrderProductModel orderProduct) : base(orderProduct)
        {
        }
    }
}
