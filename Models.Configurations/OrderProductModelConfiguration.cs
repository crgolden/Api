namespace crgolden.Api
{
    using Abstractions;
    using Microsoft.AspNet.OData.Builder;

    public class OrderProductModelConfiguration : ModelConfiguration<OrderProductModel>
    {
        protected override EntityTypeConfiguration<OrderProductModel> ConfigureCurrent(ODataModelBuilder builder)
        {
            var orderProduct = builder.EntitySet<OrderProductModel>("OrderProducts").EntityType;
            orderProduct.HasKey(p => new { p.OrderId, p.ProductId });
            return orderProduct;
        }
    }
}
