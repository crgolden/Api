namespace Clarity.Api.ProductFiles
{
    using System.Collections.Generic;
    using Core;

    public class ProductFileEditRangeRequest : EditRangeRequest<ProductFile, ProductFileModel>
    {
        public ProductFileEditRangeRequest(IEnumerable<ProductFileModel> productFiles) : base(productFiles)
        {

        }
    }
}
