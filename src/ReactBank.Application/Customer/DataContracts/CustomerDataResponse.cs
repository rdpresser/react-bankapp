namespace ReactBank.Application.Customer.DataContracts
{
    /// <summary>
    /// Represents the response data contract for the customer data.
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Name"></param>
    /// <param name="Email"></param>
    /// <param name="Phone"></param>
    /// <param name="StreetAddress"></param>
    /// <param name="City"></param>
    /// <param name="State"></param>
    /// <param name="ZipCode"></param>
    /// <param name="DateOfBirth"></param>
    /// <param name="IdentityDocument"></param>
    public record CustomerDataResponse(
        Guid Id,
        string Name,
        string Email,
        string Phone,
        string StreetAddress,
        string City,
        string State,
        string ZipCode,
        string DateOfBirth,
        string IdentityDocument
    );
}
