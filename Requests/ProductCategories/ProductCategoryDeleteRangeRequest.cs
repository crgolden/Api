namespace Clarity.Api.ProductCategories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;

    public class ProductCategoryDeleteRangeRequest : DeleteRangeRequest
    {
        public ProductCategoryDeleteRangeRequest(IEnumerable<Guid[]> keyValues) : base(keyValues.Select(x => x.Cast<object>()).Cast<object[]>().ToArray())
        {
        }
    }
}
