namespace Clarity.Api
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;

    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        private readonly DatabaseOptions _options;

        public OrderProductConfiguration(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public void Configure(EntityTypeBuilder<OrderProduct> orderProduct)
        {
            orderProduct.Property(e => e.Created).HasDefaultValueSql("getutcdate()");
            orderProduct.Property(e => e.Updated);
            orderProduct.HasKey(e => new { e.OrderId, e.ProductId });
            orderProduct.Property(e => e.Quantity).HasColumnType("decimal(18,2)");
            orderProduct.HasOne(e => e.Order).WithMany(e => e.OrderProducts).HasForeignKey(e => e.OrderId);
            orderProduct.HasOne(e => e.Product).WithMany(e => e.OrderProducts).HasForeignKey(e => e.ProductId);
            orderProduct.ToTable("OrderProducts");
            if (!_options.SeedData) return;
            orderProduct.HasData(SeedOrderProducts.OrderProducts);
        }
    }
}
