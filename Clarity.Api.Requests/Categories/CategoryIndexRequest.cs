namespace Clarity.Api.Categories
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class CategoryIndexRequest : IndexRequest
    {
        public CategoryIndexRequest(ModelStateDictionary modelState = null, DataSourceRequest request = null)
            : base(modelState, request)
        {
        }
    }
}
