namespace Clarity.Api.OrderProducts
{
    using System.Collections.Generic;
    using Core;

    public class OrderProductCreateRangeRequest : CreateRangeRequest<IEnumerable<OrderProduct>, OrderProduct>
    {
        public OrderProductCreateRangeRequest(IEnumerable<OrderProduct> orderProducts) : base(orderProducts)
        {
        }
    }
}
