namespace Clarity.Api.CartProducts
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CartProductDetailsRequestHandler : DetailsRequestHandler<CartProductDetailsRequest, CartProduct, CartProductModel>
    {
        public CartProductDetailsRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
