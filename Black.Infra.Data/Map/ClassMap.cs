using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class ClassMap : EntityTypeConfiguration<Class>
    {
        public override void Map(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Class");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Date).HasColumnType("date").IsRequired();
            builder.Property(p => p.LinkClass).HasMaxLength(255);
            builder.Property(p => p.LinkInfo).HasMaxLength(255);
            builder.Property(p => p.LinkCopy).HasMaxLength(255);
            builder.Property(p => p.LinkCreative).HasMaxLength(255);
            builder.Property(p => p.LinkTraffic).HasMaxLength(255);
            builder.Property(p => p.LinkRegister).HasMaxLength(255);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
