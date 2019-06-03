namespace crgolden.Api
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CartProductConfiguration : EntityConfiguration<CartProduct>
    {
        public override void Configure(EntityTypeBuilder<CartProduct> cartProduct)
        {
            base.Configure(cartProduct);
            cartProduct.HasKey(e => new { e.CartId, e.ProductId });
            cartProduct.Property(e => e.Quantity).HasColumnType("decimal(18,2)");
            cartProduct.HasOne(e => e.Cart).WithMany(e => e.CartProducts).HasForeignKey(e => e.CartId);
            cartProduct.HasOne(e => e.Product).WithMany(e => e.CartProducts).HasForeignKey(e => e.ProductId);
            cartProduct.ToTable("CartProducts");
        }
    }
}
