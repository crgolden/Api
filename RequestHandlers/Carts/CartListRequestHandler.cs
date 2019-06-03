namespace crgolden.Api.Carts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartListRequestHandler : ListRequestHandler<CartListRequest, Cart, CartModel>
    {
        public CartListRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
