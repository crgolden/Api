namespace Clarity.Api.Carts
{
    using System.Collections.Generic;
    using Core;

    public class CartCreateRangeRequest : CreateRangeRequest<IEnumerable<CartModel>, Cart, CartModel>
    {
        public CartCreateRangeRequest(IEnumerable<CartModel> carts) : base(carts)
        {
        }
    }
}
