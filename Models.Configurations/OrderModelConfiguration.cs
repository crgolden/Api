namespace crgolden.Api
{
    using Abstractions;
    using Microsoft.AspNet.OData.Builder;

    public class OrderModelConfiguration : ModelConfiguration<OrderModel>
    {
        protected override EntityTypeConfiguration<OrderModel> ConfigureCurrent(ODataModelBuilder builder)
        {
            var order = builder.EntitySet<OrderModel>("Orders").EntityType;
            order.HasKey(p => p.Id);
            return order;
        }
    }
}
