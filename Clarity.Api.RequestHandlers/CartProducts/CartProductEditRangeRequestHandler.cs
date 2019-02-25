namespace Clarity.Api.CartProducts
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartProductEditRangeRequestHandler : EditRangeRequestHandler<CartProductEditRangeRequest, CartProduct, CartProductModel>
    {
        public CartProductEditRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
