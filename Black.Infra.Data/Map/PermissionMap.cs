using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Black.Domain.Models;
using Black.Infra.Data.Extensions;

namespace Black.Infra.Data.Map
{
    public class PermissionMap : EntityTypeConfiguration<Permission>
    {
        public override void Map(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.ConstPermission).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(500);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
