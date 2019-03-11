namespace Clarity.Api
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;

    public class OrderConfiguration : EntityConfiguration<Order>
    {
        private readonly DatabaseOptions _options;

        public OrderConfiguration(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public override void Configure(EntityTypeBuilder<Order> order)
        {
            base.Configure(order);
            order.Property(e => e.Number).ValueGeneratedOnAdd();
            order.HasIndex(e => e.Number).IsUnique();
            order.Property(e => e.UserId).IsRequired();
            order.Property(e => e.Shipping).HasColumnType("decimal(18,2)");
            order.Property(e => e.Tax).HasColumnType("decimal(18,2)");
            order.Property(e => e.Total).HasColumnType("decimal(18,2)");
            order.HasMany(e => e.OrderProducts).WithOne(e => e.Order).HasForeignKey(e => e.OrderId);
            order.HasMany(e => e.Payments).WithOne(e => e.Order).HasForeignKey(e => e.OrderId);
            order.Metadata.SetNavigationAccessMode(PropertyAccessMode.Field);

            var shippingAddress = order.OwnsOne(e => e.ShippingAddress);
            shippingAddress.Property(e => e.StreetAddress).HasColumnName("ShippingStreet");
            shippingAddress.Property(e => e.Locality).HasColumnName("ShippingCity");
            shippingAddress.Property(e => e.Region).HasColumnName("ShippingState");
            shippingAddress.Property(e => e.PostalCode).HasColumnName("ShippingZipCode");
            shippingAddress.Property(e => e.Country).HasColumnName("ShippingCountry");
            order.ToTable("Orders");
            if (!_options.SeedData) return;
            shippingAddress.HasData(SeedAddresses.Addresses);
            order.HasData(SeedOrders.Orders);
        }
    }
}
