namespace Clarity.Api.Configurations
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
            cartProduct.Ignore(e => e.ThumbnailUri);
            cartProduct.Property(e => e.Price).HasColumnType("decimal(18,2)");
            cartProduct.Property(e => e.Quantity).HasColumnType("decimal(18,2)");
            cartProduct.Property(e => e.IsDownload);
            cartProduct.Property(e => e.ProductName);
            cartProduct.HasOne(e => e.Cart).WithMany(e => e.CartProducts).HasForeignKey(e => e.CartId);
            cartProduct.HasOne(e => e.Product).WithMany(e => e.CartProducts).HasForeignKey(e => e.ProductId);
            cartProduct.ToTable("CartProducts");
        }
    }
}
