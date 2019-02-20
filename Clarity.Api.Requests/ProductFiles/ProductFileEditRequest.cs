namespace Clarity.Api.ProductFiles
{
    using Core;

    public class ProductFileEditRequest : EditRequest<ProductFile>
    {
        public ProductFileEditRequest(ProductFile productFile) : base(productFile)
        {
        }
    }
}
