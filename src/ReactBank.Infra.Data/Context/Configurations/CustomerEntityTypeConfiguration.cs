using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactBank.Domain.Models;
using ReactBank.Infra.Data.Context.Configurations.Base;

namespace ReactBank.Infra.Data.Context.Configurations
{
    public class CustomerEntityTypeConfiguration : BaseEntityTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.Phone)
                .IsRequired();

            builder.Property(x => x.City)
                .IsRequired(false);

            builder.Property(x => x.State)
                .IsRequired(false);

            builder.Property(x => x.ZipCode)
                .IsRequired();

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Email);

            builder.HasOne(x => x.Account)
                .WithOne(x => x.Customer)
                .HasForeignKey<Account>(x => x.CustomerId);
        }
    }
}
