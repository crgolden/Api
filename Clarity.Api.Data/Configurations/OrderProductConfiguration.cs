namespace Clarity.Api.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> orderProduct)
        {
            orderProduct.Property(e => e.Created);
            orderProduct.Property(e => e.Updated);
            orderProduct.Ignore(e => e.ThumbnailUri);
            orderProduct.HasKey(e => new { e.OrderId, e.ProductId });
            orderProduct.Property(e => e.Price).HasColumnType("decimal(18,2)");
            orderProduct.Property(e => e.Quantity).HasColumnType("decimal(18,2)");
            orderProduct.Property(e => e.ProductName).IsRequired();
            orderProduct.HasOne(e => e.Order).WithMany(e => e.OrderProducts).HasForeignKey(e => e.OrderId);
            orderProduct.HasOne(e => e.Product).WithMany(e => e.OrderProducts).HasForeignKey(e => e.ProductId);
            orderProduct.ToTable("OrderProducts");
        }
    }
}
