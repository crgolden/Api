namespace crgolden.Api.ProductFiles
{
    using Abstractions;

    public class ProductFileUpdateRequest : UpdateRequest<ProductFile, ProductFileModel>
    {
        public ProductFileUpdateRequest(ProductFileModel productFile) : base(productFile)
        {
        }
    }
}
