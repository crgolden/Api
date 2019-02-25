namespace Clarity.Api.Carts
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartEditRequestHandler : EditRequestHandler<CartEditRequest, Cart, CartModel>
    {
        public CartEditRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
