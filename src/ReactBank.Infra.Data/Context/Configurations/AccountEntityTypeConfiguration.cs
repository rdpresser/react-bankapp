using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactBank.Domain.Models;
using ReactBank.Infra.Data.Context.Configurations.Base;

namespace ReactBank.Infra.Data.Context.Configurations
{
    public class AccountEntityTypeConfiguration : BaseEntityTypeConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Balance)
                .IsRequired();

            builder.Property(x => x.AccountNumber)
                .IsRequired();

            builder.Property(x => x.AccountType)
                .IsRequired();

            builder.Property(x => x.Currency)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Account)
                .HasForeignKey<Account>(x => x.CustomerId);

            builder.HasMany(x => x.Loans)
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.AccountId);

            builder.HasMany(x => x.Transactions)
                .WithOne(x => x.SourceAccount)
                .HasForeignKey(x => x.SourceAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany<Transaction>()
                .WithOne(x => x.DestinationAccount)
                .HasForeignKey(x => x.DestinationAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
