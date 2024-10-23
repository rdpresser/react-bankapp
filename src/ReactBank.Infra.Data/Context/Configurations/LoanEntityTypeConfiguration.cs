using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactBank.Domain.Models;
using ReactBank.Infra.Data.Context.Configurations.Base;

namespace ReactBank.Infra.Data.Context.Configurations
{
    public class LoanEntityTypeConfiguration : BaseEntityTypeConfiguration<Loan>
    {
        public override void Configure(EntityTypeBuilder<Loan> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.Property(x => x.InterestRate)
                .IsRequired();

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.EndDate)
                .IsRequired();

            //For future versions
            //builder.Property(x => x.LoanType)
            //    .IsRequired();

            //builder.Property(x => x.LoanStatus)
            //    .IsRequired();

            builder.Property(x => x.AccountId)
                .IsRequired();

            builder.HasOne(x => x.Account)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.AccountId);
        }
    }
}
