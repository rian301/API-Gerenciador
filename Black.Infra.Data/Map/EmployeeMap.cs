using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public override void Map(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.RG).HasMaxLength(20);
            builder.Property(p => p.CPF).HasMaxLength(11);
            builder.Property(p => p.CNPJ).HasMaxLength(14);
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);
            builder.Property(p => p.BirthDate).HasColumnType("date");
            builder.Property(p => p.AdmissionDate).HasColumnType("date");
            builder.Property(p => p.DemissionDate).HasMaxLength(100);
            builder.Property(p => p.Function).HasMaxLength(100);
            builder.Property(p => p.MonthlyHour).HasMaxLength(20);
            builder.Property(p => p.WorkSchedule);
            builder.Property(p => p.Gender).HasMaxLength(100);
            builder.Property(p => p.PIS).HasMaxLength(100);
            builder.Property(p => p.Mom).HasMaxLength(100);
            builder.Property(p => p.Father).HasMaxLength(100);
            builder.Property(p => p.Schooling).HasMaxLength(100);
            builder.Property(p => p.Agency).HasMaxLength(20);
            builder.Property(p => p.Acount).HasMaxLength(20);
            builder.Property(p => p.Pix).HasMaxLength(40);
            builder.Property(p => p.VoterTitle).HasMaxLength(20);
            builder.Property(p => p.ReservistCertificate).HasMaxLength(20);
            builder.Property(p => p.Wage).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Benefit).HasMaxLength(20);
            builder.Property(p => p.ZipCode).HasMaxLength(20);
            builder.Property(p => p.Street).HasMaxLength(200);
            builder.Property(p => p.Number).HasMaxLength(20);
            builder.Property(p => p.Complement).HasMaxLength(100);
            builder.Property(p => p.District).HasMaxLength(100);
            builder.Property(p => p.City).HasMaxLength(100);
            builder.Property(p => p.Country).HasMaxLength(100);
            builder.Property(p => p.State).HasMaxLength(100);
            builder.Property(p => p.Status).HasMaxLength(100);
            builder.Property(p => p.Note).HasMaxLength(1000);
            builder.Property(p => p.Type).HasMaxLength(1000);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
