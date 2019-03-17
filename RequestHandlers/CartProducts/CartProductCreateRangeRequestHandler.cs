namespace Clarity.Api.CartProducts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartProductCreateRangeRequestHandler : CreateRangeRequestHandler<CartProductCreateRangeRequest, CartProduct, CartProductModel>
    {
        public CartProductCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
