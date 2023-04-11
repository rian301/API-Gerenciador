using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class SentMap : EntityTypeConfiguration<Sent>
    {
        public override void Map(EntityTypeBuilder<Sent> builder)
        {
            builder.ToTable("Sent");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.AwardId).IsRequired();
            builder.Property(p => p.CustomerId);
            builder.Property(p => p.MentoredId);
            builder.Property(p => p.DateRequest).HasColumnType("date");
            builder.Property(p => p.DateSend).HasColumnType("date");
            builder.Property(p => p.DateReceiving).HasColumnType("date");
            builder.Property(p => p.Requester);
            builder.Property(p => p.Campaign);
            builder.Property(p => p.Email);
            builder.Property(p => p.Code);
            builder.Property(p => p.Status);
            builder.Property(p => p.ZipCode);
            builder.Property(p => p.Street);
            builder.Property(p => p.Number);
            builder.Property(p => p.Complement);
            builder.Property(p => p.District);
            builder.Property(p => p.City);
            builder.Property(p => p.Country);
            builder.Property(p => p.State);
            builder.Property(p => p.Note);


            builder.HasOne(p => p.Award).WithMany().HasForeignKey(f => f.AwardId);
            builder.HasOne(p => p.Customer).WithMany().HasForeignKey(f => f.CustomerId);
            builder.HasOne(p => p.Mentored).WithMany().HasForeignKey(f => f.MentoredId);

            builder.Ignore(x => x.ValidationResult);
        }
    }
}
