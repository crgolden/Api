namespace crgolden.Api.ProductFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;

    public class ProductFileDeleteRangeRequest : DeleteRangeRequest
    {
        public ProductFileDeleteRangeRequest(IEnumerable<Guid[]> keyValues) : base(keyValues.Select(x => x.Cast<object>()).Cast<object[]>().ToArray())
        {
        }
    }
}
