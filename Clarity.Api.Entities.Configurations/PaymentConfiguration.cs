namespace Clarity.Api
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;

    public class PaymentConfiguration : EntityConfiguration<Payment>
    {
        private readonly DatabaseOptions _options;

        public PaymentConfiguration(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public override void Configure(EntityTypeBuilder<Payment> payment)
        {
            base.Configure(payment);
            payment.Property(e => e.UserId).IsRequired();
            payment.Property(e => e.Amount).HasColumnType("decimal(18,2)").IsRequired();
            payment.Property(e => e.ChargeId);
            payment.Property(e => e.Currency).IsRequired();
            payment.Property(e => e.TokenId).IsRequired();
            payment.Property(e => e.CustomerCode).IsRequired();
            payment.Property(e => e.Description);
            payment.HasOne(e => e.Order).WithMany(e => e.Payments).HasForeignKey(e => e.OrderId);
            payment.Metadata.SetNavigationAccessMode(PropertyAccessMode.Field);
            payment.ToTable("Payments");
            if (!_options.SeedData) return;
            payment.HasData(SeedPayments.Payments);
        }
    }
}
