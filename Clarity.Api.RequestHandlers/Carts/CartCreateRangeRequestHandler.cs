namespace Clarity.Api.Carts
{
    using System.Collections.Generic;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartCreateRangeRequestHandler : CreateRangeRequestHandler<CartCreateRangeRequest, IEnumerable<CartModel>, Cart, CartModel>
    {
        public CartCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
