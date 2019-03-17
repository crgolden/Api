namespace Clarity.Api.Categories
{
    using Abstractions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class CategoryListRequest : ListRequest<Category, CategoryModel>
    {
        public CategoryListRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
