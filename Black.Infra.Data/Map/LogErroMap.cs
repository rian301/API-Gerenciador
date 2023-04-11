using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class LogErroMap : EntityTypeConfiguration<LogErro>
    {
        public override void Map(EntityTypeBuilder<LogErro> builder)
        {
            builder.ToTable("LogError");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);
            builder.Property(p => p.LogDate);
            builder.Property(p => p.System);
            builder.Property(p => p.Class);
            builder.Property(p => p.Context);
            builder.Property(p => p.Request);
            builder.Property(p => p.Error);

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
        }
    }
}
