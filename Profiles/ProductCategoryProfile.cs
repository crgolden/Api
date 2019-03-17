namespace Clarity.Api
{
    using AutoMapper;

    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategoryModel, ProductCategory>(MemberList.Destination)
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
