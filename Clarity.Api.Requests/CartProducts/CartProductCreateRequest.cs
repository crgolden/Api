namespace Clarity.Api.CartProducts
{
    using Core;

    public class CartProductCreateRequest : CreateRequest<CartProduct>
    {
        public CartProductCreateRequest(CartProduct cartProduct) : base(cartProduct)
        {
        }
    }
}
