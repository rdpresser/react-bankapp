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

            //Property configurations
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

            //Index configurations
            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Email);

            //Global query filter - make sure only active records are listed
            builder.HasQueryFilter(x => x.IsActive);

            //Seed data
            builder.HasData(
                new Customer
                {
                    Id = Guid.Parse("849b24e4-f29a-4fb4-91b7-7a9b65795bf6"),
                    IsActive = true,
                    Name = "John Doe",
                    IdentityDocument = "123456789",
                    Phone = "123456789",
                    StreetAddress = "123 Main St",
                    ZipCode = "12345",
                    State = "NY",
                    City = "New York",
                    DateOfBirth = new DateTime(1980, 1, 1),
                    Email = "john.doe@gmail.com"
                },
                new Customer
                {
                    Id = Guid.Parse("889b24e4-f29a-4fb4-91b7-7a9b65795bf6"),
                    IsActive = true,
                    Name = "Mary Doe",
                    IdentityDocument = "923456789",
                    Phone = "923456789",
                    StreetAddress = "124 Main St",
                    ZipCode = "12346",
                    State = "NY",
                    City = "New York",
                    DateOfBirth = new DateTime(1980, 1, 2),
                    Email = "mary.doe@gmail.com"
                },
                new Customer
                {
                    Id = Guid.Parse("888b24e4-f29a-4fb4-91b7-7a9b65795bf6"),
                    IsActive = false,
                    Name = "Son Doe",
                    IdentityDocument = "823456789",
                    Phone = "823456789",
                    StreetAddress = "125 Main St",
                    ZipCode = "12347",
                    State = "NY",
                    City = "New York",
                    DateOfBirth = new DateTime(1995, 1, 2),
                    Email = "son.doe@gmail.com"
                });
        }
    }
}
