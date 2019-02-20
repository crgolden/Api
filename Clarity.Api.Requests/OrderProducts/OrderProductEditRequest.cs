namespace Clarity.Api.OrderProducts
{
    using Core;

    public class OrderProductEditRequest : EditRequest<OrderProduct>
    {
        public OrderProductEditRequest(OrderProduct orderProduct) : base(orderProduct)
        {
        }
    }
}
