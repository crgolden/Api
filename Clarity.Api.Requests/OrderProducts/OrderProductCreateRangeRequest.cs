namespace Clarity.Api.OrderProducts
{
    using System.Collections.Generic;
    using Core;

    public class OrderProductCreateRangeRequest : CreateRangeRequest<IEnumerable<OrderProductModel>, OrderProduct, OrderProductModel>
    {
        public OrderProductCreateRangeRequest(IEnumerable<OrderProductModel> orderProducts) : base(orderProducts)
        {
        }
    }
}
