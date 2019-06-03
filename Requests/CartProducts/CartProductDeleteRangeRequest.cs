namespace crgolden.Api.CartProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;

    public class CartProductDeleteRangeRequest : DeleteRangeRequest
    {
        public CartProductDeleteRangeRequest(IEnumerable<Guid[]> keyValues) : base(keyValues.Select(x => x.Cast<object>()).Cast<object[]>().ToArray())
        {
        }
    }
}
