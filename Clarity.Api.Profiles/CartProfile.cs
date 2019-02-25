namespace Clarity.Api
{
    using Core;

    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartModel>();
        }
    }
}
