namespace Clarity.Api.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.Property(e => e.Created);
            category.Property(e => e.Updated);
            category.Property(e => e.Name).IsRequired();
            category.Property(e => e.Description);
            category.HasMany(e => e.ProductCategories).WithOne(e => e.Category).HasForeignKey(e => e.CategoryId);
            category.ToTable("Categories");
        }
    }
}
