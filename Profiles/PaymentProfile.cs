namespace crgolden.Api
{
    using AutoMapper;

    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentModel, Payment>()
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
