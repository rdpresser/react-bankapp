using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReactBank.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "City", "DateOfBirth", "Email", "IdentityDocument", "IsActive", "Name", "Phone", "State", "StreetAddress", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("849b24e4-f29a-4fb4-91b7-7a9b65795bf6"), "New York", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@gmail.com", "123456789", true, "John Doe", "123456789", "NY", "123 Main St", "12345" },
                    { new Guid("888b24e4-f29a-4fb4-91b7-7a9b65795bf6"), "New York", new DateTime(1995, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "son.doe@gmail.com", "823456789", false, "Son Doe", "823456789", "NY", "125 Main St", "12347" },
                    { new Guid("889b24e4-f29a-4fb4-91b7-7a9b65795bf6"), "New York", new DateTime(1980, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "mary.doe@gmail.com", "923456789", true, "Mary Doe", "923456789", "NY", "124 Main St", "12346" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountNumber", "AccountType", "Balance", "CreatedAt", "Currency", "CustomerId", "IsActive" },
                values: new object[,]
                {
                    { new Guid("ba669725-8233-434a-9b1e-751dd752e419"), "123456789", "Checking Account", 1000m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "US$", new Guid("849b24e4-f29a-4fb4-91b7-7a9b65795bf6"), true },
                    { new Guid("ba769725-8233-434a-9b1e-751dd752e419"), "923456789", "Saving Account", 900m, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "US$", new Guid("889b24e4-f29a-4fb4-91b7-7a9b65795bf6"), true },
                    { new Guid("ba869725-8233-434a-9b1e-751dd752e419"), "823456789", "Student Account", 850m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "US$", new Guid("888b24e4-f29a-4fb4-91b7-7a9b65795bf6"), false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Loan]");

            migrationBuilder.Sql("DELETE FROM [Transaction]");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("ba669725-8233-434a-9b1e-751dd752e419"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("ba769725-8233-434a-9b1e-751dd752e419"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("ba869725-8233-434a-9b1e-751dd752e419"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("849b24e4-f29a-4fb4-91b7-7a9b65795bf6"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("888b24e4-f29a-4fb4-91b7-7a9b65795bf6"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("889b24e4-f29a-4fb4-91b7-7a9b65795bf6"));
        }
    }
}
