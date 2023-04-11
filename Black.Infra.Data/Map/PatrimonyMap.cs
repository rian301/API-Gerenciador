using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class PatrimonyMap : EntityTypeConfiguration<Patrimony>
    {
        public override void Map(EntityTypeBuilder<Patrimony> builder)
        {
            builder.ToTable("Patrimony");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Tag);
            builder.Property(p => p.Brand);
            builder.Property(p => p.Nf);
            builder.Property(p => p.NumberSerie);
            builder.Property(p => p.Value).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PurchaseDate).HasColumnType("date");
            builder.Property(p => p.ProviderId);
            builder.Property(p => p.AssetsCategoryId);
            builder.Property(p => p.Note);
            builder.Property(p => p.Status);

            builder.HasOne(p => p.Provider).WithMany().HasForeignKey(f => f.ProviderId);
            builder.HasOne(p => p.AssetsCategory).WithMany().HasForeignKey(f => f.AssetsCategoryId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
