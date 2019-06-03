namespace crgolden.Api.CartProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;

    public class CartProductReadRangeRequest: ReadRangeRequest<CartProduct, CartProductModel>
    {
        public CartProductReadRangeRequest(IEnumerable<Guid[]> keyValues) : base(keyValues.Select(x => x.Cast<object>()).Cast<object[]>().ToArray())
        {
        }
    }
}
