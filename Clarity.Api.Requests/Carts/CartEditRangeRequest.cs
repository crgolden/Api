namespace Clarity.Api.Carts
{
    using System.Collections.Generic;
    using Core;

    public class CartEditRangeRequest : EditRangeRequest<Cart, CartModel>
    {
        public CartEditRangeRequest(IEnumerable<CartModel> carts) : base(carts)
        {
        }
    }
}
