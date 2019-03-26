namespace Clarity.Api
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;
    using Shared;

    public class ProductCategoryConfiguration : EntityConfiguration<ProductCategory>
    {
        private readonly DatabaseOptions _options;

        public ProductCategoryConfiguration(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public override void Configure(EntityTypeBuilder<ProductCategory> productCategory)
        {
            productCategory.HasKey(e => new { e.ProductId, e.CategoryId });
            productCategory.HasOne(e => e.Product).WithMany(e => e.ProductCategories).HasForeignKey(e => e.ProductId);
            productCategory.HasOne(e => e.Category).WithMany(e => e.ProductCategories).HasForeignKey(e => e.CategoryId);
            productCategory.ToTable("ProductCategories");
            if (!_options.SeedData) return;
            productCategory.HasData(SeedProductCategories.ProductCategories);
        }
    }
}
