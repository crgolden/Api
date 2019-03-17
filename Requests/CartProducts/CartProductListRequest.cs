namespace Clarity.Api.CartProducts
{
    using System;
    using Abstractions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class CartProductListRequest : ListRequest<CartProduct, CartProductModel>
    {
        public Guid? UserId { get; set; }

        public CartProductListRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
