using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class MentoredMap : EntityTypeConfiguration<Mentored>
    {
        public override void Map(EntityTypeBuilder<Mentored> builder)
        {
            builder.ToTable("Mentored");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Email).HasMaxLength(255);
            builder.Property(p => p.RG).HasMaxLength(20);
            builder.Property(p => p.CPF).HasMaxLength(11);
            builder.Property(p => p.PhoneNumber).HasMaxLength(14);
            builder.Property(p => p.BirthDate).HasColumnType("date");
            builder.Property(p => p.ZipCode).HasMaxLength(80);
            builder.Property(p => p.Street).HasMaxLength(200);
            builder.Property(p => p.Number).HasMaxLength(20);
            builder.Property(p => p.Complement).HasMaxLength(200);
            builder.Property(p => p.District).HasMaxLength(70);
            builder.Property(p => p.City).HasMaxLength(70);
            builder.Property(p => p.Country).HasMaxLength(70);
            builder.Property(p => p.State).HasMaxLength(2);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.Instagram);
            builder.Property(p => p.Status);
            builder.Property(p => p.IsPartner).IsRequired();
            builder.Property(p => p.Off).HasMaxLength(1000);
            builder.Property(p => p.Note).HasMaxLength(1000);
            builder.Property(p => p.Deleted).HasMaxLength(1);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
