namespace Clarity.Api.Carts
{
    using Core;

    public class CartCreateRequest : CreateRequest<Cart>
    {
        public CartCreateRequest(Cart cart) : base(cart)
        {
        }
    }
}
