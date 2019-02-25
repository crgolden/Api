namespace Clarity.Api
{
    using Core;

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.ImageThumbnailUri, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUri, opt => opt.Ignore());
        }
    }
}
