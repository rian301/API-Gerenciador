using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class SubscriptionMap : EntityTypeConfiguration<Subscription>
    {
        public override void Map(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.MentoredId).IsRequired();
            builder.Property(p => p.MentoredCompanyId);
            builder.Property(p => p.CurrentPeriodId);
            builder.Property(p => p.Status);
            builder.Property(p => p.MotiveCanceled).HasMaxLength(1000);
            builder.Property(p => p.RequestCancelMotive).HasMaxLength(1000);
            builder.Property(p => p.SubscriptionDate).HasColumnType("date");
            builder.Property(p => p.EndSubscriptionDate).HasColumnType("date");
            builder.Property(p => p.OverdueSince).HasColumnType("date");

            builder.HasOne(p => p.Product).WithMany().HasForeignKey(f => f.ProductId);
            builder.HasOne(p => p.Mentored).WithMany().HasForeignKey(f => f.MentoredId);
            builder.HasOne(p => p.MentoredCompany).WithMany().HasForeignKey(f => f.MentoredCompanyId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
