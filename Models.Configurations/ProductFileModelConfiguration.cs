namespace crgolden.Api
{
    using Abstractions;
    using Microsoft.AspNet.OData.Builder;

    public class ProductFileModelConfiguration : ModelConfiguration<ProductFileModel>
    {
        protected override EntityTypeConfiguration<ProductFileModel> ConfigureCurrent(ODataModelBuilder builder)
        {
            var productFile = builder.EntitySet<ProductFileModel>("ProductFiles").EntityType;
            productFile.HasKey(p => new { p.ProductId, p.FileId });
            return productFile;
        }
    }
}
