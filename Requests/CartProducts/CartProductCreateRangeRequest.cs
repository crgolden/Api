namespace Clarity.Api.CartProducts
{
    using Abstractions;

    public class CartProductCreateRangeRequest : CreateRangeRequest<CartProduct, CartProductModel>
    {
        public CartProductCreateRangeRequest(CartProductModel[] cartProducts) : base(cartProducts)
        {
        }
    }
}
