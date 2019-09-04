namespace crgolden.Api
{
    using Abstractions;
    using Microsoft.AspNet.OData.Builder;

    public class CategoryModelConfiguration : ModelConfiguration<CategoryModel>
    {
        protected override EntityTypeConfiguration<CategoryModel> ConfigureCurrent(ODataModelBuilder builder)
        {
            var category = builder.EntitySet<CategoryModel>("Categories").EntityType;
            category.HasKey(p => p.Id);
            return category;
        }
    }
}
