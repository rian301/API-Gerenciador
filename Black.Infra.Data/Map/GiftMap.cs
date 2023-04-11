using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procard.Domain.Models;

namespace Black.Infra.Data.Map
{
    public class GiftMap : EntityTypeConfiguration<Gift>
    {
        public override void Map(EntityTypeBuilder<Gift> builder)
        {
            builder.ToTable("Gift");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.DateIncluse).HasColumnType("date");
            builder.Property(p => p.Responsible);
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Entrance);
            builder.Property(p => p.Exit);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
