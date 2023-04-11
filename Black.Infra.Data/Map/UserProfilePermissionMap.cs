using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class UserProfilePermissionMap : EntityTypeConfiguration<UserProfilePermission>
    {
        public override void Map(EntityTypeBuilder<UserProfilePermission> builder)
        {
            builder.ToTable("UserProfilePermission");
            builder.HasKey(p => new { p.UserProfileId, p.PermissionId });

            builder.HasOne(x => x.UserProfile).WithMany(z => z.Permissions).HasForeignKey(x => x.UserProfileId);
            builder.HasOne(x => x.Permission).WithMany().HasForeignKey(x => x.PermissionId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
