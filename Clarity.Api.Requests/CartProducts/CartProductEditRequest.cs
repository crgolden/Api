namespace Clarity.Api.CartProducts
{
    using Core;

    public class CartProductEditRequest : EditRequest<CartProduct, CartProductModel>
    {
        public CartProductEditRequest(CartProductModel cartProduct) : base(cartProduct)
        {
        }
    }
}
