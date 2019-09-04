namespace crgolden.Api
{
    using Abstractions;
    using Microsoft.AspNet.OData.Builder;

    public class ProductModelConfiguration : ModelConfiguration<ProductModel>
    {
        protected override EntityTypeConfiguration<ProductModel> ConfigureCurrent(ODataModelBuilder builder)
        {
            var product = builder.EntitySet<ProductModel>("Products").EntityType;
            product.HasKey(p => p.Id);
            return product;
        }
    }
}
