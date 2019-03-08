namespace Clarity.Api
{
    using AutoMapper;

    public class CartProductProfile : Profile
    {
        public CartProductProfile()
        {
            CreateMap<CartProductModel, CartProduct>(MemberList.Destination)
                .ForMember(dest => dest.Cart, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.ProductImageThumbnailUri, opt => opt.Ignore());
        }
    }
}
