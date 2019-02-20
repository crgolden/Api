namespace Clarity.Api.ProductFiles
{
    using System.Collections.Generic;
    using Core;

    public class ProductFileCreateRangeRequest : CreateRangeRequest<IEnumerable<ProductFile>, ProductFile>
    {
        public ProductFileCreateRangeRequest(IEnumerable<ProductFile> productFiles) : base(productFiles)
        {
        }
    }
}
