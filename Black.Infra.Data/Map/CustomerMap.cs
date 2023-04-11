using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Black.Domain.Models;
using Black.Infra.Data.Extensions;

namespace Black.Infra.Data.Map
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public override void Map(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
            builder.Property(p => p.RG).HasMaxLength(20);
            builder.Property(p => p.Document).HasMaxLength(100);
            builder.Property(p => p.PhoneNumber).HasMaxLength(100);
            builder.Property(p => p.BirthDate).HasColumnType("date");
            builder.Property(p => p.ZipCode).HasMaxLength(20);
            builder.Property(p => p.Street).HasMaxLength(200);
            builder.Property(p => p.Number).HasMaxLength(20);
            builder.Property(p => p.Complement).HasMaxLength(200);
            builder.Property(p => p.District).HasMaxLength(70);
            builder.Property(p => p.City).HasMaxLength(70);
            builder.Property(p => p.Country).HasMaxLength(70);
            builder.Property(p => p.State).HasMaxLength(100);
            builder.Property(p => p.Status);
            builder.Property(p => p.ProductId);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.Note).HasMaxLength(1000);
            builder.Property(p => p.ImportCode).HasMaxLength(50);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
