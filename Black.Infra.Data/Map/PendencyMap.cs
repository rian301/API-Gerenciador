using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class PendencyMap : EntityTypeConfiguration<Pendency>
    {
        public override void Map(EntityTypeBuilder<Pendency> builder)
        {
            builder.ToTable("Pendency");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.IncludDate).HasColumnType("date");
            builder.Property(p => p.ResolveDate).HasColumnType("date");
            builder.Property(p => p.Requester);
            builder.Property(p => p.Responsible);
            builder.Property(p => p.Description);
            builder.Property(p => p.Status);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);

    }
    }
}
