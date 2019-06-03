namespace crgolden.Api
{
    using AutoMapper;

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryModel, Category>(MemberList.Destination)
                .ForMember(dest => dest.ProductCategories, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
