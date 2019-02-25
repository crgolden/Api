namespace Clarity.Api.CartProducts
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartProductCreateRequestHandler : CreateRequestHandler<CartProductCreateRequest, CartProduct, CartProductModel>
    {
        public CartProductCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
