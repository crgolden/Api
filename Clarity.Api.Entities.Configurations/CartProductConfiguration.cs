namespace Clarity.Api
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> cartProduct)
        {
            cartProduct.Property(e => e.Created);
            cartProduct.Property(e => e.Updated);
            cartProduct.HasKey(e => new { e.CartId, e.ProductId });
            cartProduct.Property(e => e.Quantity).HasColumnType("decimal(18,2)");
            cartProduct.HasOne(e => e.Cart).WithMany(e => e.CartProducts).HasForeignKey(e => e.CartId);
            cartProduct.HasOne(e => e.Product).WithMany(e => e.CartProducts).HasForeignKey(e => e.ProductId);
            cartProduct.ToTable("CartProducts");
        }
    }
}
