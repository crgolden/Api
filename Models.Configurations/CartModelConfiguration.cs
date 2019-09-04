namespace crgolden.Api
{
    using Abstractions;
    using Microsoft.AspNet.OData.Builder;

    public class CartModelConfiguration : ModelConfiguration<CartModel>
    {
        protected override EntityTypeConfiguration<CartModel> ConfigureCurrent(ODataModelBuilder builder)
        {
            var cart = builder.EntitySet<CartModel>("Carts").EntityType;
            cart.HasKey(p => p.Id);
            return cart;
        }
    }
}
