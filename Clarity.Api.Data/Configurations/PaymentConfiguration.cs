namespace Clarity.Api.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
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
            payment.ToTable("Payments");
        }
    }
}
