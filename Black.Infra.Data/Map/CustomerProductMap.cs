using Black.Domain.Models;
using Black.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Black.Infra.Data.Map
{
    public class CustomerProductMap : EntityTypeConfiguration<CustomerProduct>
    {
        public override void Map(EntityTypeBuilder<CustomerProduct> builder)
        {
            builder.ToTable("CustomerProduct");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.DatePurchase).HasColumnType("date").IsRequired();
            builder.Property(p => p.ProductId).IsRequired();

            builder.HasOne(x => x.Customer).WithMany(w => w.CustomerProducts).HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
