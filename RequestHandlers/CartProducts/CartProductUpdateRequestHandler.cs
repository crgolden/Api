namespace crgolden.Api.CartProducts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartProductUpdateRequestHandler : UpdateRequestHandler<CartProductUpdateRequest, CartProduct, CartProductModel>
    {
        public CartProductUpdateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
