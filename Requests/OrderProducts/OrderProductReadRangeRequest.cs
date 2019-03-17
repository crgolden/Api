namespace Clarity.Api.OrderProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;

    public class OrderProductReadRangeRequest: ReadRangeRequest<OrderProduct, OrderProductModel>
    {
        public OrderProductReadRangeRequest(IEnumerable<Guid[]> keyValues) : base(keyValues.Select(x => x.Cast<object>()).Cast<object[]>().ToArray())
        {
        }
    }
}
