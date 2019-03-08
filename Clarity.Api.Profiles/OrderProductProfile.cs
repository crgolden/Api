namespace Clarity.Api
{
    using AutoMapper;

    public class OrderProductProfile : Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProductModel, OrderProduct>(MemberList.Destination)
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.ProductImageThumbnailUri, opt => opt.Ignore());
        }
    }
}
