namespace Clarity.Api.Carts
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class CartIndexRequest : IndexRequest<Cart, CartModel>
    {
        public CartIndexRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
