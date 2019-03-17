namespace Clarity.Api.CartProducts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartProductReadRangeRequestHandler : ReadRangeRequestHandler<CartProductReadRangeRequest, CartProduct, CartProductModel>
    {
        public CartProductReadRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
