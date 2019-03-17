namespace Clarity.Api.CartProducts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartProductUpdateRangeRequestHandler : UpdateRangeRequestHandler<CartProductUpdateRangeRequest, CartProduct, CartProductModel>
    {
        public CartProductUpdateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
