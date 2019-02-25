namespace Clarity.Api
{
    using System.Linq;
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;

    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        private readonly DatabaseOptions _options;

        public PaymentConfiguration(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public void Configure(EntityTypeBuilder<Payment> payment)
        {
            payment.Property(e => e.Created);
            payment.Property(e => e.Updated);
            payment.Property(e => e.UserId).IsRequired();
            payment.Property(e => e.Amount).HasColumnType("decimal(18,2)").IsRequired();
            payment.Property(e => e.ChargeId);
            payment.Property(e => e.Currency).IsRequired();
            payment.Property(e => e.TokenId).IsRequired();
            payment.Property(e => e.CustomerCode).IsRequired();
            payment.Property(e => e.Description);
            payment.HasOne(e => e.Order).WithMany(e => e.Payments).HasForeignKey(e => e.OrderId);
            foreach (var collection in payment.Metadata.GetNavigations().Where(x => x.IsCollection()))
            {
                collection.SetPropertyAccessMode(PropertyAccessMode.Field);
            }
            payment.ToTable("Payments");
            if (!_options.SeedData) return;
            payment.HasData(SeedPayments.Payments);
        }
    }
}
