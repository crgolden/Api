namespace Clarity.Api.OrderProducts
{
    using System.Collections.Generic;
    using Core;

    public class OrderProductEditRangeRequest : EditRangeRequest<OrderProduct, OrderProductModel>
    {
        public OrderProductEditRangeRequest(IEnumerable<OrderProductModel> orderProducts) : base(orderProducts)
        {
        }
    }
}
