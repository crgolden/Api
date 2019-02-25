namespace Clarity.Api.ProductFiles
{
    using Core;

    public class ProductFileCreateRequest : CreateRequest<ProductFile, ProductFileModel>
    {
        public ProductFileCreateRequest(ProductFileModel productFile) : base(productFile)
        {
        }
    }
}
