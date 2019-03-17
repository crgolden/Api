namespace Clarity.Api.CartProducts
{
    using Abstractions;

    public class CartProductUpdateRangeRequest : UpdateRangeRequest<CartProduct, CartProductModel>
    {
        public CartProductUpdateRangeRequest(CartProductModel[] cartProducts) : base(cartProducts)
        {
        }
    }
}
