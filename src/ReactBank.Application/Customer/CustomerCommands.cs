namespace ReactBank.Application.Customer
{
    /// <summary>
    /// Create a new customer
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Email"></param>
    /// <param name="Phone"></param>
    /// <param name="StreetAddress"></param>
    /// <param name="City"></param>
    /// <param name="State"></param>
    /// <param name="ZipCode"></param>
    /// <param name="DateOfBirth"></param>
    /// <param name="IdentityDocument"></param>
    public record CreateCustomerCommand(
        string Name,
        string Email,
        string Phone,
        string StreetAddress,
        string City,
        string State,
        string ZipCode,
        DateTime DateOfBirth,
        string IdentityDocument
    );

    /// <summary>
    /// Update an existing customer
    /// </summary>
    /// <param name="CustomerId"></param>
    /// <param name="Name"></param>
    /// <param name="Email"></param>
    /// <param name="Phone"></param>
    /// <param name="StreetAddress"></param>
    /// <param name="City"></param>
    /// <param name="State"></param>
    /// <param name="ZipCode"></param>
    /// <param name="DateOfBirth"></param>
    /// <param name="IdentityDocument"></param>
    public record UpdateCustomerCommand(
        Guid CustomerId,
        string Name,
        string Email,
        string Phone,
        string StreetAddress,
        string City,
        string State,
        string ZipCode,
        DateTime DateOfBirth,
        string IdentityDocument
    );

    /// <summary>
    /// Delete an existing customer
    /// </summary>
    /// <param name="CustomerId"></param>
    public record DeleteCustomerCommand(
        Guid CustomerId
    );
}
