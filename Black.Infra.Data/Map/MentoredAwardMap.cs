using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class MentoredAwardMap : EntityTypeConfiguration<MentoredAward>
    {
        public override void Map(EntityTypeBuilder<MentoredAward> builder)
        {
            builder.ToTable("MentoredAward");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.DateSend).HasColumnType("date");
            builder.Property(p => p.DateReceiving).HasColumnType("date");
            builder.Property(p => p.MentoredId).IsRequired();
            builder.Property(p => p.Note).HasMaxLength(1000);

            builder.HasOne(x => x.Mentored).WithMany(w => w.MentoredAwards).HasForeignKey(x => x.MentoredId);
            builder.HasOne(x => x.Award).WithMany().HasForeignKey(x => x.AwardId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
