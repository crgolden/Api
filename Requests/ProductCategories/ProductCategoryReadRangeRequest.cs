namespace crgolden.Api.ProductCategories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;

    public class ProductCategoryReadRangeRequest : ReadRangeRequest<ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryReadRangeRequest(IEnumerable<Guid[]> keyValues) : base(keyValues.Select(x => x.Cast<object>()).Cast<object[]>().ToArray())
        {
        }
    }
}
