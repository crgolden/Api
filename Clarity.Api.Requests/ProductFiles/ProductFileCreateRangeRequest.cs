namespace Clarity.Api.ProductFiles
{
    using System.Collections.Generic;
    using Core;

    public class ProductFileCreateRangeRequest : CreateRangeRequest<IEnumerable<ProductFileModel>, ProductFile, ProductFileModel>
    {
        public ProductFileCreateRangeRequest(IEnumerable<ProductFileModel> productFiles) : base(productFiles)
        {
        }
    }
}
