namespace Clarity.Api
{
    using Core;

    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryModel>();
        }
    }
}
