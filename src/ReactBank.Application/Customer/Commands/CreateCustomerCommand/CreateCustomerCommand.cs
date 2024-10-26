using MediatR;
using ReactBank.Application.Customer.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Customer.Commands.CreateCustomerCommand
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
    ) : IRequest<Result<CustomerDataResponse>>;
}
