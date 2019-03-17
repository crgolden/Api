namespace Clarity.Api
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CartConfiguration : EntityConfiguration<Cart>
    {
        public override void Configure(EntityTypeBuilder<Cart> cart)
        {
            base.Configure(cart);
            cart.HasIndex(e => e.UserId).IsUnique();
            cart.HasMany(e => e.CartProducts).WithOne(e => e.Cart).HasForeignKey(e => e.CartId);
            cart.Metadata.SetNavigationAccessMode(PropertyAccessMode.Field);
            cart.ToTable("Carts");
        }
    }
}
