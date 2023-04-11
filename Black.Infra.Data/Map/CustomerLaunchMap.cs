using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class CustomerLaunchMap : EntityTypeConfiguration<CustomerLaunch>
    {
        public override void Map(EntityTypeBuilder<CustomerLaunch> builder)
        {
            builder.ToTable("CustomerLaunch");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Nicho).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Instagram).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Invoice).HasColumnType("decimal(18,2)").HasMaxLength(8);
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.Testimonial).HasMaxLength(255);

            builder.HasOne(x => x.Customer).WithMany(w => w.CustomersLaunch).HasForeignKey(x => x.CustomerId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
