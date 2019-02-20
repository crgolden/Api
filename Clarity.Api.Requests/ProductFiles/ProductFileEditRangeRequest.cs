namespace Clarity.Api.ProductFiles
{
    using System.Collections.Generic;
    using Core;

    public class ProductFileEditRangeRequest : EditRangeRequest<ProductFile>
    {
        public ProductFileEditRangeRequest(IEnumerable<ProductFile> productFiles) : base(productFiles)
        {

        }
    }
}
