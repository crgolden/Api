namespace crgolden.Api.Carts
{
    using Abstractions;

    public class CartUpdateRequest : UpdateRequest<Cart, CartModel>
    {
        public CartUpdateRequest(CartModel cart) : base(cart)
        {
        }
    }
}
