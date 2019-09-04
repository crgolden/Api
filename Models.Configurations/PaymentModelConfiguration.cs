namespace crgolden.Api
{
    using Abstractions;
    using Microsoft.AspNet.OData.Builder;

    public class PaymentModelConfiguration : ModelConfiguration<PaymentModel>
    {
        protected override EntityTypeConfiguration<PaymentModel> ConfigureCurrent(ODataModelBuilder builder)
        {
            var payment = builder.EntitySet<PaymentModel>("Payments").EntityType;
            payment.HasKey(p => p.Id);
            return payment;
        }
    }
}
