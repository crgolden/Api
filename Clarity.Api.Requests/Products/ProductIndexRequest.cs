namespace Clarity.Api.Products
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class ProductIndexRequest : IndexRequest
    {
        public bool Active { get; set; }

        public ProductIndexRequest(ModelStateDictionary modelState = null, DataSourceRequest request = null)
            : base(modelState, request)
        {
        }
    }
}
