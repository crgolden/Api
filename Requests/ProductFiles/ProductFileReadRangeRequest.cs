namespace Clarity.Api.ProductFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;

    public class ProductFileReadRangeRequest: ReadRangeRequest<ProductFile, ProductFileModel>
    {
        public ProductFileReadRangeRequest(IEnumerable<Guid[]> keyValues) : base(keyValues.Select(x => x.Cast<object>()).Cast<object[]>().ToArray())
        {
        }
    }
}
