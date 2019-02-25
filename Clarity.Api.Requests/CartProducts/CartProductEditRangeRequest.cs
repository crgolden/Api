namespace Clarity.Api.CartProducts
{
    using System.Collections.Generic;
    using Core;

    public class CartProductEditRangeRequest : EditRangeRequest<CartProduct, CartProductModel>
    {
        public CartProductEditRangeRequest(IEnumerable<CartProductModel> cartProducts) : base(cartProducts)
        {
        }
    }
}
