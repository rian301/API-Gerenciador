using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class PendencyDocMap : EntityTypeConfiguration<PendencyDoc>
    {
        public override void Map(EntityTypeBuilder<PendencyDoc> builder)
        {
            builder.ToTable("PendencyDoc");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.PendencyId).IsRequired();
            builder.Property(p => p.FileName).HasMaxLength(250);
            builder.Property(p => p.Container).HasMaxLength(50);
            builder.Property(p => p.TypeDoc).IsRequired();
            builder.Property(p => p.Extension).HasMaxLength(5);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.Active).IsRequired();

            builder.HasOne(p => p.Pendency).WithMany().HasForeignKey(f => f.PendencyId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);

        }
    }
}
