namespace crgolden.Api.ProductFiles
{
    using Abstractions;

    public class ProductFileUpdateRangeRequest : UpdateRangeRequest<ProductFile, ProductFileModel>
    {
        public ProductFileUpdateRangeRequest(ProductFileModel[] productFiles) : base(productFiles)
        {

        }
    }
}
