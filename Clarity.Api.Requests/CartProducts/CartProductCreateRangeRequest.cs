namespace Clarity.Api.CartProducts
{
    using System.Collections.Generic;
    using Core;

    public class CartProductCreateRangeRequest : CreateRangeRequest<IEnumerable<CartProduct>, CartProduct>
    {
        public CartProductCreateRangeRequest(IEnumerable<CartProduct> cartProducts) : base(cartProducts)
        {
        }
    }
}
