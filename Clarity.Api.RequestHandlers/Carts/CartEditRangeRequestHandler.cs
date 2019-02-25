namespace Clarity.Api.Carts
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartEditRangeRequestHandler : EditRangeRequestHandler<CartEditRangeRequest, Cart, CartModel>
    {
        public CartEditRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
