using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class DailyPaymentDocMap : EntityTypeConfiguration<DailyPaymentDoc>
    {

        public override void Map(EntityTypeBuilder<DailyPaymentDoc> builder)
        {
            builder.ToTable("DailyPaymentDoc");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.DailyPaymentId).IsRequired();
            builder.Property(p => p.FileName).HasMaxLength(250);
            builder.Property(p => p.Container).HasMaxLength(50);
            builder.Property(p => p.TypeDoc).IsRequired();
            builder.Property(p => p.Extension).HasMaxLength(5);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.Active).IsRequired();

            builder.HasOne(p => p.DailyPayment).WithMany().HasForeignKey(f => f.DailyPaymentId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
