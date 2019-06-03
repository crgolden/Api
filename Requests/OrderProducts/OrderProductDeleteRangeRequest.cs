namespace crgolden.Api.OrderProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;

    public class OrderProductDeleteRangeRequest : DeleteRangeRequest
    {
        public OrderProductDeleteRangeRequest(IEnumerable<Guid[]> keyValues) : base(keyValues.Select(x => x.Cast<object>()).Cast<object[]>().ToArray())
        {
        }
    }
}
