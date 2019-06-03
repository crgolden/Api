namespace crgolden.Api.OrderProducts
{
    using Abstractions;

    public class OrderProductUpdateRangeRequest : UpdateRangeRequest<OrderProduct, OrderProductModel>
    {
        public OrderProductUpdateRangeRequest(OrderProductModel[] orderProducts) : base(orderProducts)
        {
        }
    }
}
