namespace Clarity.Api.Carts
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class CartIndexRequest : IndexRequest
    {
        public CartIndexRequest(ModelStateDictionary modelState = null, DataSourceRequest request = null)
            : base(modelState, request)
        {
        }
    }
}
