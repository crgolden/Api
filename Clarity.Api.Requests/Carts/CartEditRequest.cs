namespace Clarity.Api.Carts
{
    using Core;

    public class CartEditRequest : EditRequest<Cart, CartModel>
    {
        public CartEditRequest(CartModel cart) : base(cart)
        {
        }
    }
}
