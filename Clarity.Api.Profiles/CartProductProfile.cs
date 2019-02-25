namespace Clarity.Api
{
    using Core;

    public class CartProductProfile : Profile
    {
        public CartProductProfile()
        {
            CreateMap<CartProduct, CartProductModel>();
        }
    }
}
