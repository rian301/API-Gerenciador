using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class ExpenseControlMap : EntityTypeConfiguration<ExpenseControl>
    {
        public override void Map(EntityTypeBuilder<ExpenseControl> builder)
        {
            builder.ToTable("ExpenseControl");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.ProviderId).IsRequired();
            builder.Property(p => p.Value).IsRequired().HasColumnType("decimal(18,2)").HasMaxLength(8);
            builder.Property(p => p.Date).IsRequired().HasColumnType("date");
            builder.Property(p => p.PaymentDate).IsRequired().HasColumnType("date");
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Deleted).HasMaxLength(1);
            builder.Property(p => p.Note).HasMaxLength(1000);

            builder.HasOne(p => p.Provider).WithMany().HasForeignKey(f => f.ProviderId);
            builder.HasOne(p => p.ExpenseCategory).WithMany().HasForeignKey(f => f.ExpenseCategoryId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
