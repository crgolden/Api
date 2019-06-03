namespace crgolden.Api.CartProducts
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartProductDeleteRangeRequestHandler : DeleteRangeRequestHandler<CartProductDeleteRangeRequest, CartProduct>
    {
        public CartProductDeleteRangeRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
