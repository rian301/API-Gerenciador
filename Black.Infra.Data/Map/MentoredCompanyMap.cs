using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class MentoredCompanyMap : EntityTypeConfiguration<MentoredCompany>
    {
        public override void Map(EntityTypeBuilder<MentoredCompany> builder)
        {
            builder.ToTable("MentoredCompany");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.CompanyName).IsRequired();
            builder.Property(p => p.SubscriptionDate).HasColumnType("date");
            builder.Property(p => p.CNPJ);
            builder.Property(p => p.ZipCode);
            builder.Property(p => p.Street);
            builder.Property(p => p.Number);
            builder.Property(p => p.Complement);
            builder.Property(p => p.District);
            builder.Property(p => p.City);
            builder.Property(p => p.State);
            builder.Property(p => p.Email);
            builder.Property(p => p.Instagram);
            builder.Property(p => p.Phone);
            builder.Property(p => p.Note).HasMaxLength(1000);

            builder.HasOne(p => p.Mentored).WithMany(p => p.MentoredCompanies).HasForeignKey(f => f.MentoredId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
