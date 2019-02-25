namespace Clarity.Api
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;

    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        private readonly DatabaseOptions _options;

        public ProductCategoryConfiguration(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public void Configure(EntityTypeBuilder<ProductCategory> productCategory)
        {
            productCategory.Property(e => e.Created);
            productCategory.Property(e => e.Updated);
            productCategory.HasKey(e => new { e.ProductId, e.CategoryId });
            productCategory.HasOne(e => e.Product).WithMany(e => e.ProductCategories).HasForeignKey(e => e.ProductId);
            productCategory.HasOne(e => e.Category).WithMany(e => e.ProductCategories).HasForeignKey(e => e.CategoryId);
            productCategory.ToTable("ProductCategories");
            if (_options.SeedData) return;
            productCategory.HasData(SeedProductCategories.ProductCategories);
        }
    }
}
