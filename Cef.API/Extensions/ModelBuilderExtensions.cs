namespace Cef.API.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Relationships;

    public static class ModelBuilderExtensions
    {
        public static void ConfigureECommerceContext(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(b =>
            {
                b.HasIndex(e => e.UserId).IsUnique();
                b.Property(e => e.Total).HasColumnType("decimal(18,2)");
                b.HasMany(e => e.CartProducts).WithOne(e => e.Model1).HasForeignKey(e => e.Model1Id);
                b.ToTable("Carts");
            });

            modelBuilder.Entity<Category>(b =>
            {
                b.HasMany(e => e.ProductCategories).WithOne(e => e.Model2).HasForeignKey(e => e.Model2Id);
                b.ToTable("Categories");
            });

            modelBuilder.Entity<File>(b =>
            {
                b.HasMany(e => e.ProductFiles).WithOne(e => e.Model2).HasForeignKey(e => e.Model2Id);
                b.ToTable("Files");
            });

            modelBuilder.Entity<Order>(b =>
            {
                b.Property(e => e.Total).HasColumnType("decimal(18,2)");
                b.HasMany(e => e.OrderProducts).WithOne(e => e.Model1).HasForeignKey(e => e.Model1Id);
                b.HasMany(e => e.Payments).WithOne(e => e.Order).HasForeignKey(e => e.OrderId);
                b.ToTable("Orders");
            });

            modelBuilder.Entity<Payment>(b =>
            {
                b.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                b.HasOne(e => e.Order).WithMany(e => e.Payments).HasForeignKey(e => e.OrderId);
                b.ToTable("Payments");
            });

            modelBuilder.Entity<Product>(b =>
            {
                b.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                b.HasMany(e => e.CartProducts).WithOne(e => e.Model2).HasForeignKey(e => e.Model2Id);
                b.HasMany(e => e.OrderProducts).WithOne(e => e.Model2).HasForeignKey(e => e.Model2Id);
                b.HasMany(e => e.ProductCategories).WithOne(e => e.Model1).HasForeignKey(e => e.Model1Id);
                b.HasMany(e => e.ProductFiles).WithOne(e => e.Model1).HasForeignKey(e => e.Model1Id);
                b.ToTable("Products");
            });

            modelBuilder.Entity<CartProduct>(b =>
            {
                b.HasKey(e => new { e.Model1Id, e.Model2Id });
                b.Property(e => e.Price).HasColumnType("decimal(18,2)");
                b.Property(e => e.Quantity).HasColumnType("decimal(18,2)");
                b.HasOne(e => e.Model1).WithMany(e => e.CartProducts).HasForeignKey(e => e.Model1Id);
                b.HasOne(e => e.Model2).WithMany(e => e.CartProducts).HasForeignKey(e => e.Model2Id);
                b.ToTable("CartProducts");
            });

            modelBuilder.Entity<OrderProduct>(b =>
            {
                b.HasKey(e => new { e.Model1Id, e.Model2Id });
                b.Property(e => e.Price).HasColumnType("decimal(18,2)");
                b.Property(e => e.Quantity).HasColumnType("decimal(18,2)");
                b.HasOne(e => e.Model1).WithMany(e => e.OrderProducts).HasForeignKey(e => e.Model1Id);
                b.HasOne(e => e.Model2).WithMany(e => e.OrderProducts).HasForeignKey(e => e.Model2Id);
                b.ToTable("OrderProducts");
            });

            modelBuilder.Entity<ProductFile>(b =>
            {
                b.HasKey(e => new { e.Model1Id, e.Model2Id });
                b.HasOne(e => e.Model1).WithMany(e => e.ProductFiles).HasForeignKey(e => e.Model1Id);
                b.HasOne(e => e.Model2).WithMany(e => e.ProductFiles).HasForeignKey(e => e.Model2Id);
                b.ToTable("ProductFiles");
            });

            modelBuilder.Entity<ProductCategory>(b =>
            {
                b.HasKey(e => new { e.Model1Id, e.Model2Id });
                b.HasOne(e => e.Model1).WithMany(e => e.ProductCategories).HasForeignKey(e => e.Model1Id);
                b.HasOne(e => e.Model2).WithMany(e => e.ProductCategories).HasForeignKey(e => e.Model2Id);
                b.ToTable("ProductCategories");
            });
        }
    }
}