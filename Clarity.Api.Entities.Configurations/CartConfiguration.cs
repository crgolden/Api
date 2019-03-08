namespace Clarity.Api
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> cart)
        {
            cart.Property(e => e.Created).HasDefaultValueSql("getutcdate()");
            cart.Property(e => e.Updated);
            cart.HasIndex(e => e.UserId).IsUnique();
            cart.HasMany(e => e.CartProducts).WithOne(e => e.Cart).HasForeignKey(e => e.CartId);
            cart.Metadata.SetNavigationAccessMode(PropertyAccessMode.Field);
            cart.ToTable("Carts");
        }
    }
}
