using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class DailyPaymentMap : EntityTypeConfiguration<DailyPayment>
    {
        public override void Map(EntityTypeBuilder<DailyPayment> builder)
        {
            builder.ToTable("DailyPayment");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Amount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.Bank);
            builder.Property(p => p.Acount);
            builder.Property(p => p.Agency);
            builder.Property(p => p.Pix);
            builder.Property(p => p.DatePayment);
            builder.Property(p => p.DateSchedulingPayment);
            builder.Property(p => p.ProviderId).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.Deleted).HasMaxLength(1);

            builder.HasOne(p => p.Provider).WithMany().HasForeignKey(p => p.ProviderId);
            builder.HasOne(p => p.ExpenseCategory).WithMany().HasForeignKey(p => p.CategoryId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
