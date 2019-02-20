namespace Clarity.Api.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> productCategory)
        {
            productCategory.Property(e => e.Created);
            productCategory.Property(e => e.Updated);
            productCategory.HasKey(e => new { e.ProductId, e.CategoryId });
            productCategory.Property(e => e.ProductName).IsRequired();
            productCategory.Property(e => e.CategoryName).IsRequired();
            productCategory.HasOne(e => e.Product).WithMany(e => e.ProductCategories).HasForeignKey(e => e.ProductId);
            productCategory.HasOne(e => e.Category).WithMany(e => e.ProductCategories).HasForeignKey(e => e.CategoryId);
            productCategory.ToTable("ProductCategories");
        }
    }
}
