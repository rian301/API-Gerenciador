using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procard.Domain.Models;

namespace Black.Infra.Data.Map
{
    public class InvoiceMap : EntityTypeConfiguration<Invoice>
    {
        public override void Map(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.SubscriptionId).IsRequired();
            builder.Property(p => p.MentoredId).IsRequired();
            builder.Property(p => p.Amount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.NextAttempt).HasColumnType("date");
            builder.Property(p => p.CanceledDate).HasColumnType("date");
            builder.Property(p => p.ExpirationDate).HasColumnType("date");
            builder.Property(p => p.PaidDate).HasColumnType("date");
            builder.Property(p => p.OverdueSince).HasColumnType("date");

            builder.HasOne(p => p.Subscription).WithMany(a => a.Invoices).HasForeignKey(f => f.SubscriptionId);
            builder.HasOne(p => p.Mentored).WithMany().HasForeignKey(f => f.MentoredId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
