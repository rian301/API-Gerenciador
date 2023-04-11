using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class AppMap : EntityTypeConfiguration<App>
    {
        public override void Map(EntityTypeBuilder<App> builder)
        {
            builder.ToTable("App");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.DatePurchase).HasColumnType("date");
            builder.Property(p => p.Requester).IsRequired();
            builder.Property(p => p.Value).IsRequired().HasColumnType("decimal(18,2)").HasMaxLength(8);
            builder.Property(p => p.Signature);
            builder.Property(p => p.Description);
            builder.Property(p => p.Responsible).IsRequired();
            builder.Property(p => p.DateCanceled).HasColumnType("date");
            builder.Property(p => p.MotiveCancel);
            builder.Property(p => p.Note);
            builder.Property(p => p.Status);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}