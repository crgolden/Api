﻿namespace crgolden.Api
{
    using Abstractions;
    using Shared;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;

    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        private readonly DatabaseOptions _options;

        public CategoryConfiguration(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public override void Configure(EntityTypeBuilder<Category> category)
        {
            base.Configure(category);
            category.Property(e => e.Name).IsRequired();
            category.HasIndex(e => e.Name).IsUnique();
            category.Property(e => e.Description);
            category.HasMany(e => e.ProductCategories).WithOne(e => e.Category).HasForeignKey(e => e.CategoryId);
            category.Metadata.SetNavigationAccessMode(PropertyAccessMode.Field);
            category.ToTable("Categories");
            if (!_options.SeedData) return;
            category.HasData(SeedCategories.Categories);
        }
    }
}
