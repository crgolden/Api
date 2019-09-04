namespace crgolden.Api.Categories
{
    using Abstractions;
    using Microsoft.AspNet.OData.Query;

    public class CategoryListRequest : ListRequest<Category, CategoryModel>
    {
        public CategoryListRequest(ODataQueryOptions<CategoryModel> options) : base(options)
        {
        }
    }
}
