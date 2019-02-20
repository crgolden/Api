namespace Clarity.Api.CartProducts
{
    using Core;

    public class CartProductEditRequest : EditRequest<CartProduct>
    {
        public CartProductEditRequest(CartProduct cartProduct) : base(cartProduct)
        {
        }
    }
}
