namespace Clarity.Api
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;

    public class ProductConfiguration : EntityConfiguration<Product>
    {
        private readonly DatabaseOptions _options;

        public ProductConfiguration(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public override void Configure(EntityTypeBuilder<Product> product)
        {
            base.Configure(product);
            product.Property(e => e.Name).IsRequired();
            product.HasIndex(e => e.Name).IsUnique();
            product.HasIndex(e => e.Sku).IsUnique();
            product.Property(e => e.Active);
            product.Property(e => e.Description);
            product.Property(e => e.IsDownload);
            product.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
            product.Property(e => e.QuantityPerUnit).IsRequired();
            product.Property(e => e.ReorderLevel);
            product.Property(e => e.UnitsInStock);
            product.Property(e => e.UnitsOnOrder);
            product.HasMany(e => e.CartProducts).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);
            product.HasMany(e => e.OrderProducts).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);
            product.HasMany(e => e.ProductCategories).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);
            product.HasMany(e => e.ProductFiles).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);
            product.Metadata.SetNavigationAccessMode(PropertyAccessMode.Field);
            product.ToTable("Products");
            if (!_options.SeedData) return;
            product.HasData(SeedProducts.Products);
        }
    }
}
