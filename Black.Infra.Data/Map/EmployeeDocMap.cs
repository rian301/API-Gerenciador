using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class EmployeeDocMap : EntityTypeConfiguration<EmployeeDoc>
    {

        public override void Map(EntityTypeBuilder<EmployeeDoc> builder)
        {
            builder.ToTable("EmployeeDoc");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.EmployeeId).IsRequired();
            builder.Property(p => p.FileName).HasMaxLength(250);
            builder.Property(p => p.Container).HasMaxLength(50);
            builder.Property(p => p.Extension).HasMaxLength(5);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.Active).IsRequired();

            builder.HasOne(p => p.Employee).WithMany().HasForeignKey(f => f.EmployeeId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
