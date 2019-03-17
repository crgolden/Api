namespace Clarity.Api.Carts
{
    using Abstractions;

    public class CartCreateRequest : CreateRequest<Cart, CartModel>
    {
        public CartCreateRequest(CartModel cart) : base(cart)
        {
        }
    }
}
