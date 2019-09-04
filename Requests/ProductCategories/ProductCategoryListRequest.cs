namespace crgolden.Api.ProductCategories
{
    using Abstractions;
    using Microsoft.AspNet.OData.Query;

    public class ProductCategoryListRequest : ListRequest<ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryListRequest(ODataQueryOptions<ProductCategoryModel> options) : base(options)
        {
        }
    }
}
