namespace Clarity.Api
{
    using AutoMapper;

    public class ProductFileProfile : Profile
    {
        public ProductFileProfile()
        {
            CreateMap<ProductFileModel, ProductFile>(MemberList.Destination)
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.File, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
