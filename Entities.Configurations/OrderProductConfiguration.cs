namespace Clarity.Api
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;
    using Shared;

    public class OrderProductConfiguration : EntityConfiguration<OrderProduct>
    {
        private readonly DatabaseOptions _options;

        public OrderProductConfiguration(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public override void Configure(EntityTypeBuilder<OrderProduct> orderProduct)
        {
            base.Configure(orderProduct);
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
