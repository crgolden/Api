namespace Clarity.Api
{
    using AutoMapper;

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, Product>(MemberList.Destination)
                .ForMember(dest => dest.CartProducts, opt => opt.Ignore())
                .ForMember(dest => dest.OrderProducts, opt => opt.Ignore())
                .ForMember(dest => dest.ProductCategories, opt => opt.Ignore())
                .ForMember(dest => dest.ProductFiles, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.ImageThumbnailUri, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUri, opt => opt.Ignore());
        }
    }
}
