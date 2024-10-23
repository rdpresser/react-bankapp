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

            //Property configurations
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

            //Relationships
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

            //Global query filter
            builder.HasQueryFilter(x => x.IsActive);

            //Seed data
            builder.HasData(
                new Account
                {
                    Id = Guid.Parse("ba669725-8233-434a-9b1e-751dd752e419"),
                    AccountNumber = "123456789",
                    Balance = 1000,
                    Currency = "US$",
                    AccountType = "Checking Account",
                    IsActive = true,
                    CustomerId = Guid.Parse("849b24e4-f29a-4fb4-91b7-7a9b65795bf6")
                },
                new Account
                {
                    Id = Guid.Parse("ba769725-8233-434a-9b1e-751dd752e419"),
                    AccountNumber = "923456789",
                    Balance = 900,
                    Currency = "US$",
                    AccountType = "Saving Account",
                    IsActive = true,
                    CustomerId = Guid.Parse("889b24e4-f29a-4fb4-91b7-7a9b65795bf6")
                },
                new Account
                {
                    Id = Guid.Parse("ba869725-8233-434a-9b1e-751dd752e419"),
                    AccountNumber = "823456789",
                    Balance = 850,
                    Currency = "US$",
                    AccountType = "Student Account",
                    IsActive = false,
                    CustomerId = Guid.Parse("888b24e4-f29a-4fb4-91b7-7a9b65795bf6")
                });
        }
    }
}
