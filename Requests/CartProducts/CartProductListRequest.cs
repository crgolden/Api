namespace crgolden.Api.CartProducts
{
    using System;
    using Abstractions;
    using Microsoft.AspNet.OData.Query;

    public class CartProductListRequest : ListRequest<CartProduct, CartProductModel>
    {
        public Guid? UserId { get; set; }

        public CartProductListRequest(ODataQueryOptions<CartProductModel> options) : base(options)
        {
        }
    }
}
