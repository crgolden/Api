namespace crgolden.Api
{
    using Abstractions;
    using Microsoft.AspNet.OData.Builder;

    public class ProductCategoryModelConfiguration : ModelConfiguration<ProductCategoryModel>
    {
        protected override EntityTypeConfiguration<ProductCategoryModel> ConfigureCurrent(ODataModelBuilder builder)
        {
            var productCategory = builder.EntitySet<ProductCategoryModel>("ProductCategories").EntityType;
            productCategory.HasKey(p => new { p.ProductId, p.CategoryId });
            return productCategory;
        }
    }
}
