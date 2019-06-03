namespace crgolden.Api.CartProducts
{
    using Abstractions;

    public class CartProductCreateRequest : CreateRequest<CartProduct, CartProductModel>
    {
        public CartProductCreateRequest(CartProductModel cartProduct) : base(cartProduct)
        {
        }
    }
}
