using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class PartnerMap : EntityTypeConfiguration<Partner>
    {
        public override void Map(EntityTypeBuilder<Partner> builder)
        {
            builder.ToTable("Partner");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.MentoredId).IsRequired();

            builder.HasOne(p => p.Mentored).WithMany(p => p.Partners).HasForeignKey(f => f.MentoredId);
            builder.HasOne(p => p.Mentored).WithMany(p => p.Partners).HasForeignKey(f => f.MentoredId);

            builder.Ignore(x => x.ValidationResult);
        }
    }
}
