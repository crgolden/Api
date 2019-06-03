namespace crgolden.Api.Carts
{
    using Abstractions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class CartListRequest : ListRequest<Cart, CartModel>
    {
        public CartListRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
