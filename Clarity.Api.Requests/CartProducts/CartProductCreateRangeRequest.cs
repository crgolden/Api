namespace Clarity.Api.CartProducts
{
    using System.Collections.Generic;
    using Core;

    public class CartProductCreateRangeRequest : CreateRangeRequest<IEnumerable<CartProductModel>, CartProduct, CartProductModel>
    {
        public CartProductCreateRangeRequest(IEnumerable<CartProductModel> cartProducts) : base(cartProducts)
        {
        }
    }
}
