namespace crgolden.Api
{
    using Abstractions;
    using Microsoft.AspNet.OData.Builder;

    public class CartProductModelConfiguration : ModelConfiguration<CartProductModel>
    {
        protected override EntityTypeConfiguration<CartProductModel> ConfigureCurrent(ODataModelBuilder builder)
        {
            var cartProduct = builder.EntitySet<CartProductModel>("CartProducts").EntityType;
            cartProduct.HasKey(p => new { p.CartId, p.ProductId });
            return cartProduct;
        }
    }
}
