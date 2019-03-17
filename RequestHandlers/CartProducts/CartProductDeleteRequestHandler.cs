namespace Clarity.Api.CartProducts
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartProductDeleteRequestHandler : DeleteRequestHandler<CartProductDeleteRequest, CartProduct>
    {
        public CartProductDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
