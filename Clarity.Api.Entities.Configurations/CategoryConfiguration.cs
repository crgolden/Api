namespace Clarity.Api
{
    using System.Linq;
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly DatabaseOptions _options;

        public CategoryConfiguration(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.Property(e => e.Created);
            category.Property(e => e.Updated);
            category.Property(e => e.Name).IsRequired();
            category.Property(e => e.Description);
            category.HasMany(e => e.ProductCategories).WithOne(e => e.Category).HasForeignKey(e => e.CategoryId);
            foreach (var collection in category.Metadata.GetNavigations().Where(x => x.IsCollection()))
            {
                collection.SetPropertyAccessMode(PropertyAccessMode.Field);
            }
            category.ToTable("Categories");
            if (_options.SeedData) return;
            category.HasData(SeedCategories.Categories);
        }
    }
}
