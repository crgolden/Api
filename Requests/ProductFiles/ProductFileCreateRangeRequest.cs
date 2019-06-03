namespace crgolden.Api.ProductFiles
{
    using Abstractions;

    public class ProductFileCreateRangeRequest : CreateRangeRequest<ProductFile, ProductFileModel>
    {
        public ProductFileCreateRangeRequest(ProductFileModel[] productFiles) : base(productFiles)
        {
        }
    }
}
