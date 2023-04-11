using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class AwardMap : EntityTypeConfiguration<Award>
    {
        public override void Map(EntityTypeBuilder<Award> builder)
        {
            builder.ToTable("Award");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired();

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
