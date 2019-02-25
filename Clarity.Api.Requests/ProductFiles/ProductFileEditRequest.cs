namespace Clarity.Api.ProductFiles
{
    using Core;

    public class ProductFileEditRequest : EditRequest<ProductFile, ProductFileModel>
    {
        public ProductFileEditRequest(ProductFileModel productFile) : base(productFile)
        {
        }
    }
}
