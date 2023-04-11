using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class ProviderMap : EntityTypeConfiguration<Provider>
    {
        public override void Map(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Provider");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Document);
            builder.Property(p => p.Bank);
            builder.Property(p => p.Acount);
            builder.Property(p => p.Agency);
            builder.Property(p => p.Pix);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
