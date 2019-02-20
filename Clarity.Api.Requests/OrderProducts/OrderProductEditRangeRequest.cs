namespace Clarity.Api.OrderProducts
{
    using System.Collections.Generic;
    using Core;

    public class OrderProductEditRangeRequest : EditRangeRequest<OrderProduct>
    {
        public OrderProductEditRangeRequest(IEnumerable<OrderProduct> orderProducts) : base(orderProducts)
        {
        }
    }
}
