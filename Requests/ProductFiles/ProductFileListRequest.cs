namespace crgolden.Api.ProductFiles
{
    using Abstractions;
    using Microsoft.AspNet.OData.Query;

    public class ProductFileListRequest : ListRequest<ProductFile, ProductFileModel>
    {
        public ProductFileListRequest(ODataQueryOptions<ProductFileModel> options) : base(options)
        {
        }
    }
}
