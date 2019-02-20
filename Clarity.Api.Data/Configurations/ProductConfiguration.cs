namespace Clarity.Api.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            product.Property(e => e.Created);
            product.Property(e => e.Updated);
            product.HasIndex(e => e.Name).IsUnique();
            product.HasIndex(e => e.Sku).IsUnique();
            product.Property(e => e.Active);
            product.Property(e => e.Description);
            product.Property(e => e.IsDownload).IsRequired();
            product.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
            product.Property(e => e.QuantityPerUnit).IsRequired();
            product.Property(e => e.ReorderLevel);
            product.Property(e => e.UnitsInStock);
            product.Property(e => e.UnitsOnOrder);
            product.HasMany(e => e.CartProducts).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);
            product.HasMany(e => e.OrderProducts).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);
            product.HasMany(e => e.ProductCategories).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);
            product.HasMany(e => e.ProductFiles).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);
            product.ToTable("Products");
        }
    }
}
