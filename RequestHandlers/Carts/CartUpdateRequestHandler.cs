namespace crgolden.Api.Carts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartUpdateRequestHandler : UpdateRequestHandler<CartUpdateRequest, Cart, CartModel>
    {
        public CartUpdateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
