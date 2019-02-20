namespace Clarity.Api.CartProducts
{
    using System.Collections.Generic;
    using Core;

    public class CartProductEditRangeRequest : EditRangeRequest<CartProduct>
    {
        public CartProductEditRangeRequest(IEnumerable<CartProduct> cartProducts) : base(cartProducts)
        {
        }
    }
}
