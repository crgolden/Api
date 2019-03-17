namespace Clarity.Api.OrderProducts
{
    using Abstractions;

    public class OrderProductCreateRangeRequest : CreateRangeRequest<OrderProduct, OrderProductModel>
    {
        public OrderProductCreateRangeRequest(OrderProductModel[] orderProducts) : base(orderProducts)
        {
        }
    }
}
