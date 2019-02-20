namespace Clarity.Api.Carts
{
    using Core;

    public class CartEditRequest : EditRequest<Cart>
    {
        public CartEditRequest(Cart cart) : base(cart)
        {
        }
    }
}
