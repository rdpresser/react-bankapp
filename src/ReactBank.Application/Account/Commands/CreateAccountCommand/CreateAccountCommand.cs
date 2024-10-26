using MediatR;
using ReactBank.Application.Account.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Enums;

namespace ReactBank.Application.Account.Commands.CreateAccountCommand
{
    /// <summary>
    /// Create a new account
    /// </summary>
    /// <param name="AccountNumber"></param>
    /// <param name="Balance"></param>
    /// <param name="Currency"></param>
    /// <param name="AccountType"></param>
    /// <param name="CustomerId"></param>
    public record CreateAccountCommand(
        string AccountNumber,
        decimal Balance,
        string Currency,
        AccountType AccountType,
        Guid CustomerId
    ) : IRequest<Result<AccountDataResponse>>;
}
