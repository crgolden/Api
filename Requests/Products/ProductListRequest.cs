namespace crgolden.Api.Products
{
    using Abstractions;
    using Microsoft.AspNet.OData.Query;

    public class ProductListRequest : ListRequest<Product, ProductModel>
    {
        public bool Active { get; set; }

        public ProductListRequest(ODataQueryOptions<ProductModel> options) : base(options)
        {
        }
    }
}
