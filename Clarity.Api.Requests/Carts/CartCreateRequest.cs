namespace Clarity.Api.Carts
{
    using Core;

    public class CartCreateRequest : CreateRequest<Cart, CartModel>
    {
        public CartCreateRequest(CartModel cart) : base(cart)
        {
        }
    }
}
