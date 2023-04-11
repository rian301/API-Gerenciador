using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class CustomerPaymentMap : EntityTypeConfiguration<CustomerPayment>
    {
        public override void Map(EntityTypeBuilder<CustomerPayment> builder)
        {
            builder.ToTable("CustomerPayment");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.SignatureDate).HasColumnType("date");
            builder.Property(p => p.CancelDate).HasColumnType("date");
            builder.Property(p => p.PaymentMethodId).IsRequired();
            builder.Property(p => p.Note).HasMaxLength(1000);

            builder.HasOne(x => x.Customer).WithMany(w => w.CustomerPayments).HasForeignKey(x => x.CustomerId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
