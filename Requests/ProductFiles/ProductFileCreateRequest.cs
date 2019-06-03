namespace crgolden.Api.ProductFiles
{
    using Abstractions;

    public class ProductFileCreateRequest : CreateRequest<ProductFile, ProductFileModel>
    {
        public ProductFileCreateRequest(ProductFileModel productFile) : base(productFile)
        {
        }
    }
}
