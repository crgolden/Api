namespace Clarity.Api.Categories
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class CategoryIndexRequest : IndexRequest<Category, CategoryModel>
    {
        public CategoryIndexRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
