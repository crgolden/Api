namespace Clarity.Api
{
    using AutoMapper;

    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderModel, Order>(MemberList.Destination)
                .ForMember(dest => dest.OrderProducts, opt => opt.Ignore())
                .ForMember(dest => dest.Payments, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
