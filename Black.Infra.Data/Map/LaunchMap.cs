using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class LaunchMap : EntityTypeConfiguration<Launch>
    {
        public override void Map(EntityTypeBuilder<Launch> builder)
        {
            builder.ToTable("Launch");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Description).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Invoice).IsRequired().HasColumnType("decimal(18,2)").HasMaxLength(8);
            builder.Property(p => p.Investment).IsRequired().HasColumnType("decimal(18,2)").HasMaxLength(8);
            builder.Property(p => p.QuantityStudents).IsRequired().HasMaxLength(4);
            builder.Property(p => p.TopCriative).HasMaxLength(100);
            builder.Property(p => p.Date).HasColumnType("date");
            builder.Property(p => p.Note).HasMaxLength(1000);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);

        }
    }
}
