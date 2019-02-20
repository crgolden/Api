namespace Clarity.Api.ProductFiles
{
    using Core;

    public class ProductFileCreateRequest : CreateRequest<ProductFile>
    {
        public ProductFileCreateRequest(ProductFile productFile) : base(productFile)
        {
        }
    }
}
