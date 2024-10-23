﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactBank.Infra.Data.Context;

#nullable disable

namespace ReactBank.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReactBank.Domain.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("ReactBank.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("IdentityDocument")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("State")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("Name");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ReactBank.Domain.Models.Loan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Loan");
                });

            modelBuilder.Entity("ReactBank.Domain.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DestinationAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SourceAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("DateTime");

                    b.HasIndex("DestinationAccountId");

                    b.HasIndex("SourceAccountId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("ReactBank.Domain.Models.Account", b =>
                {
                    b.HasOne("ReactBank.Domain.Models.Customer", "Customer")
                        .WithOne("Account")
                        .HasForeignKey("ReactBank.Domain.Models.Account", "CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ReactBank.Domain.Models.Loan", b =>
                {
                    b.HasOne("ReactBank.Domain.Models.Account", "Account")
                        .WithMany("Loans")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ReactBank.Domain.Models.Transaction", b =>
                {
                    b.HasOne("ReactBank.Domain.Models.Account", "DestinationAccount")
                        .WithMany()
                        .HasForeignKey("DestinationAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ReactBank.Domain.Models.Account", "SourceAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("SourceAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DestinationAccount");

                    b.Navigation("SourceAccount");
                });

            modelBuilder.Entity("ReactBank.Domain.Models.Account", b =>
                {
                    b.Navigation("Loans");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ReactBank.Domain.Models.Customer", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
