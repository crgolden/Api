namespace Clarity.Api
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> cart)
        {
            cart.Property(e => e.Created);
            cart.Property(e => e.Updated);
            cart.HasIndex(e => e.UserId).IsUnique();
            cart.HasMany(e => e.CartProducts).WithOne(e => e.Cart).HasForeignKey(e => e.CartId);
            foreach (var collection in cart.Metadata.GetNavigations().Where(x => x.IsCollection()))
            {
                collection.SetPropertyAccessMode(PropertyAccessMode.Field);
            }
            cart.ToTable("Carts");
        }
    }
}
