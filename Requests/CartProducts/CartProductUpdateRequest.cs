namespace crgolden.Api.CartProducts
{
    using Abstractions;

    public class CartProductUpdateRequest : UpdateRequest<CartProduct, CartProductModel>
    {
        public CartProductUpdateRequest(CartProductModel cartProduct) : base(cartProduct)
        {
        }
    }
}
