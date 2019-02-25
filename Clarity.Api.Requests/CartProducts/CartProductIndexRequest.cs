namespace Clarity.Api.CartProducts
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class CartProductIndexRequest : IndexRequest<CartProduct, CartProductModel>
    {
        public CartProductIndexRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
