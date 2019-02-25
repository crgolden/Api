namespace Clarity.Api.Carts
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartIndexRequestHandler : IndexRequestHandler<CartIndexRequest, Cart, CartModel>
    {
        public CartIndexRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
