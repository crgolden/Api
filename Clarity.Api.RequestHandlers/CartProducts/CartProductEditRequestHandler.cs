namespace Clarity.Api.CartProducts
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartProductEditRequestHandler : EditRequestHandler<CartProductEditRequest, CartProduct, CartProductModel>
    {
        public CartProductEditRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
