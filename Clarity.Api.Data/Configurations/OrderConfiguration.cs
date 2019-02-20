namespace Clarity.Api.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> order)
        {
            order.Property(e => e.Created);
            order.Property(e => e.Updated);
            order.Property(e => e.Number).ValueGeneratedOnAdd();
            order.HasIndex(e => e.Number).IsUnique();
            order.Property(e => e.UserId).IsRequired();
            order.OwnsOne(e => e.ShippingAddress).Property(e => e.StreetAddress).HasColumnName("ShippingStreet");
            order.OwnsOne(e => e.ShippingAddress).Property(e => e.Locality).HasColumnName("ShippingCity");
            order.OwnsOne(e => e.ShippingAddress).Property(e => e.Region).HasColumnName("ShippingState");
            order.OwnsOne(e => e.ShippingAddress).Property(e => e.PostalCode).HasColumnName("ShippingZipCode");
            order.OwnsOne(e => e.ShippingAddress).Property(e => e.Country).HasColumnName("ShippingCountry");
            order.Property(e => e.Total).HasColumnType("decimal(18,2)");
            order.HasMany(e => e.OrderProducts).WithOne(e => e.Order).HasForeignKey(e => e.OrderId);
            order.HasMany(e => e.Payments).WithOne(e => e.Order).HasForeignKey(e => e.OrderId);
            order.ToTable("Orders");
        }
    }
}
