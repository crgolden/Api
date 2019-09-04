namespace crgolden.Api.Carts
{
    using Abstractions;
    using Microsoft.AspNet.OData.Query;

    public class CartListRequest : ListRequest<Cart, CartModel>
    {
        public CartListRequest(ODataQueryOptions<CartModel> options) : base(options)
        {
        }
    }
}
