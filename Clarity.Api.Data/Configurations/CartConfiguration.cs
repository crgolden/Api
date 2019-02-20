namespace Clarity.Api.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> cart)
        {
            cart.Property(e => e.Created);
            cart.Property(e => e.Updated);
            cart.HasIndex(e => e.UserId).IsUnique();
            cart.Property(e => e.Total).HasColumnType("decimal(18,2)");
            cart.HasMany(e => e.CartProducts).WithOne(e => e.Cart).HasForeignKey(e => e.CartId);
            cart.ToTable("Carts");
        }
    }
}
