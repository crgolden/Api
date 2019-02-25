namespace Clarity.Api.CartProducts
{
    using System.Collections.Generic;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartProductCreateRangeRequestHandler : CreateRangeRequestHandler<CartProductCreateRangeRequest, IEnumerable<CartProductModel>, CartProduct, CartProductModel>
    {
        public CartProductCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
