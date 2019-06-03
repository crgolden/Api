namespace crgolden.Api.CartProducts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartProductReadRequestHandler : ReadRequestHandler<CartProductReadRequest, CartProduct, CartProductModel>
    {
        public CartProductReadRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
