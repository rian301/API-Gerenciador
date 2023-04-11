using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class PurchaseControlMap : EntityTypeConfiguration<PurchaseControl>
    {
        public override void Map(EntityTypeBuilder<PurchaseControl> builder)
        {
            builder.ToTable("PurchaseControl");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.RequestName);
            builder.Property(p => p.Link);
            builder.Property(p => p.Tracking);
            builder.Property(p => p.Responsible);
            builder.Property(p => p.DateLimit).HasColumnType("date");
            builder.Property(p => p.DateSolicitation).HasColumnType("date");
            builder.Property(p => p.DatePurchase).HasColumnType("date");
            builder.Property(p => p.DateDelivery).HasColumnType("date");
            builder.Property(p => p.PaymentMethodId);
            builder.Property(p => p.Note).HasMaxLength(1000);
            builder.Property(p => p.ProviderId);
            builder.Property(p => p.Quantity);
            builder.Property(p => p.Amount).HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Provider).WithMany().HasForeignKey(f => f.ProviderId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
