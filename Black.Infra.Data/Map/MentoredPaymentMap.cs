using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class MentoredPaymentMap : EntityTypeConfiguration<MentoredPayment>
    {
        public override void Map(EntityTypeBuilder<MentoredPayment> builder)
        {
            builder.ToTable("MentoredPayment");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.InitialAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.DiscountAmount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.SubscriptionDate).HasColumnType("date");
            builder.Property(p => p.SubscriptionEndDate).HasColumnType("date");
            builder.Property(p => p.DueDate).HasColumnType("date");
            builder.Property(p => p.PaymentDate).HasColumnType("date");
            builder.Property(p => p.Installments);
            builder.Property(p => p.PaymentMethodId).IsRequired();

            builder.HasOne(p => p.MentoredCompany).WithMany(a => a.MentoredPayments).HasForeignKey(f => f.MentoredCompanyId);
            builder.HasOne(p => p.Mentored).WithMany().HasForeignKey(f => f.MentoredId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
