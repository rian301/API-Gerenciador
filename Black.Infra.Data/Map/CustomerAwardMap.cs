using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class CustomerAwardMap : EntityTypeConfiguration<CustomerAward>
    {
        public override void Map(EntityTypeBuilder<CustomerAward> builder)
        {
            builder.ToTable("CustomerAward");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.DateSend).HasColumnType("date");
            builder.Property(p => p.DateReceiving).HasColumnType("date");
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.Note).HasMaxLength(1000);

            builder.HasOne(x => x.Customer).WithMany(w => w.CustomerAwards).HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.Award).WithMany().HasForeignKey(x => x.AwardId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
