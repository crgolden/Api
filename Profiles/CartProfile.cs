namespace crgolden.Api
{
    using AutoMapper;

    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartModel, Cart>(MemberList.Destination)
                .ForMember(dest => dest.CartProducts, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
