using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactBank.Domain.Models;
using ReactBank.Infra.Data.Context.Configurations.Base;

namespace ReactBank.Infra.Data.Context.Configurations
{
    public class TransactionEntityTypeConfiguration : BaseEntityTypeConfiguration<Transaction>
    {
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.Property(x => x.TransactionType)
                .IsRequired();

            builder.Property(x => x.DateTime)
                .IsRequired();

            builder.HasIndex(x => x.DateTime);
            builder.HasIndex(x => x.DestinationAccountId);
            builder.HasIndex(x => x.SourceAccountId);

            builder.HasOne(x => x.SourceAccount)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.SourceAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DestinationAccount)
                .WithMany()
                .HasForeignKey(x => x.DestinationAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
