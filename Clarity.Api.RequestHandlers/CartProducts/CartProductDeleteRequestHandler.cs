namespace Clarity.Api.CartProducts
{
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartProductDeleteRequestHandler : DeleteRequestHandler<CartProductDeleteRequest, CartProduct>
    {
        public CartProductDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
