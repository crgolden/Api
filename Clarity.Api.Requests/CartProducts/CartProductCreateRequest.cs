namespace Clarity.Api.CartProducts
{
    using Core;

    public class CartProductCreateRequest : CreateRequest<CartProduct, CartProductModel>
    {
        public CartProductCreateRequest(CartProductModel cartProduct) : base(cartProduct)
        {
        }
    }
}
