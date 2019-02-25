namespace Clarity.Api.OrderProducts
{
    using Core;

    public class OrderProductEditRequest : EditRequest<OrderProduct, OrderProductModel>
    {
        public OrderProductEditRequest(OrderProductModel orderProduct) : base(orderProduct)
        {
        }
    }
}
