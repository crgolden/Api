namespace Clarity.Api
{
    using Core;

    public class ProductFileProfile : Profile
    {
        public ProductFileProfile()
        {
            CreateMap<ProductFile, ProductFileModel>();
        }
    }
}
